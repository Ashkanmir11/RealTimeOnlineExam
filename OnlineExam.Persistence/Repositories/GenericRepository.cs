using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Helper;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(OnlineExamDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> AddAsync<TSource>(TSource source)
        {

            var entity = _mapper.Map<T>(source);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<TResult> GetAsync<TResult>(int id)
        {
            var result = await _context.Set<T>().Where(e => EF.Property<int>(e, "Id") == id).ProjectTo<TResult>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return _mapper.Map<TResult>(result);
        }
        public async Task<PaginateResponse<TResult>> GetAllAsync<TResult>(PaginateRequestDTO paginateRequestDTO)
        {
            IQueryable<T> query = _context.Set<T>();
            int totalCount = await query.CountAsync();


            int skip = PaginateHelper<T>.GetSkip(paginateRequestDTO);
            if (paginateRequestDTO.SortBy != null)
            {
                query = QuerySortHelper<T>.Sort(query, paginateRequestDTO);

            }
            query = query
                .Skip(skip)
                .Take(paginateRequestDTO.PageCount);


            var response = await query.ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync();

            var result = PaginateHelper<TResult>.Paginate(response, totalCount, paginateRequestDTO.PageCount, paginateRequestDTO.PageNumber);
            return result;
        }

        public async Task UpdateAsync<TSource>(int Id, TSource source)
        {
            var entity = await GetAsync(Id);
            _mapper.Map(source, entity);
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

      
    }
}
