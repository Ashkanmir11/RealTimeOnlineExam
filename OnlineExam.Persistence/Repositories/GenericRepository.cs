using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Helper;
using OnlineExam.Application.Response;
using OnlineExam.Persistence.Exceptions;
using System.Linq.Dynamic.Core;
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
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<T> AddAsync<TSource>(TSource source)
        {

            try
            {
                var entity = _mapper.Map<T>(source);
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)

            {
                throw;
            }

        }
        public async Task DeleteAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                {
                    throw new DbConflictException("این مورد در بخش دیگری استفاده شده و قابل حذف نیست.");
                }

                throw;
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            try
            {
                var entity = await GetAsync(id);
                return entity != null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> GetAsync(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<TResult> GetAsync<TResult>(int id)
        {
            try
            {
                var result = await _context.Set<T>().Where(e => EF.Property<int>(e, "Id") == id).ProjectTo<TResult>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
                return _mapper.Map<TResult>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<PaginateResponse<TResult>> GetAllAsync<TResult>(PaginateRequestDTO paginateRequestDTO)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();
                int totalCount = await query.CountAsync();


                int skip = PaginateHelper<T>.GetSkip(paginateRequestDTO);
                query = QuerySortHelper<T>.Sort(query, paginateRequestDTO);

                query = query
                    .Skip(skip)
                    .Take(paginateRequestDTO.PageCount);


                var response = await query.ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync();

                var result = PaginateHelper<TResult>.Paginate(response, totalCount, paginateRequestDTO);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateAsync<TSource>(int Id, TSource source)
        {
            try
            {
                var entity = await GetAsync(Id);
                _mapper.Map(source, entity);
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
