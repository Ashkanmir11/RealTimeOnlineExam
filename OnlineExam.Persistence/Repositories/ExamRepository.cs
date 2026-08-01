using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Helper;
using OnlineExam.Application.Response;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Persistence.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public ExamRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<PaginateResponse<GetExamDetailDTO>> GetByClassIdAsync(int classId, PaginateRequestDTO paginateRequestDTO)
        {
            var query = _context.Exams.Where(e => e.ClassId == classId).AsQueryable();
            int totalCount=query.Count();
            int skip = PaginateHelper<Exam>.GetSkip(paginateRequestDTO);
            query = QuerySortHelper<Exam>.Sort(query, paginateRequestDTO);
            query = query.Skip(skip).Take(paginateRequestDTO.PageCount);
            var data =await query.ProjectTo<GetExamDetailDTO>(_mapper.ConfigurationProvider).ToListAsync();
            var result = PaginateHelper<GetExamDetailDTO>.Paginate(data, totalCount, paginateRequestDTO);
            return result;
        }

        public async Task<bool> IsUserTeacherAsync(string userId, int examId)
        {
            var exam = await _context.Exams.Where(e => e.Id == examId).SingleOrDefaultAsync();
            if(exam==null)
            {
                return false;
            }
            return await _context.ClassRooms.AnyAsync(e => e.Id == exam.ClassId && e.TeacherId == userId);
        }

    }
}
