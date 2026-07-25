using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.Common;
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
    public class ClassRoomRepository : GenericRepository<ClassRoom>, IClassRoomRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public ClassRoomRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<PaginateResponse<GetClassRoomStudentDTO>> GetStudentClassesAsync(string studentId, PaginateRequestDTO paginateRequestDTO)
        {
            var studentClasses = await _context.ClassRoomMembers.Where(e => e.StudentId == studentId).Select(e => e.ClassRomeId).ToListAsync();
            if(studentClasses.Count==0)
            {
                return null;
            }
            var skip = PaginateHelper<ClassRoom>.GetSkip(paginateRequestDTO);
            int totalCount = studentClasses.Count;
            var query = _context.ClassRooms.Where(e => studentClasses.Contains(e.Id)).AsQueryable();
            query = QuerySortHelper<ClassRoom>.Sort(query, paginateRequestDTO);
            query = query.Skip(skip).Take(paginateRequestDTO.PageCount);
            var data=await query.ProjectTo<GetClassRoomStudentDTO>(_mapper.ConfigurationProvider).ToListAsync();
            var result = PaginateHelper<GetClassRoomStudentDTO>.Paginate(data, totalCount, paginateRequestDTO);
            return result;
        }

        public async Task<PaginateResponse<GetClassRoomTeacherDTO>> GetTeacherClassAsync(string teacherId, PaginateRequestDTO paginateRequestDTO)
        {
            var query = _context.ClassRooms.Where(e => e.TeacherId == teacherId).AsQueryable();
            var totalCount = _context.ClassRooms.Count();
            int skip = PaginateHelper<GetClassRoomTeacherDTO>.GetSkip(paginateRequestDTO);
            query = QuerySortHelper<ClassRoom>.Sort(query, paginateRequestDTO);
            var data = await query.Skip(skip).Take(paginateRequestDTO.PageCount).ProjectTo<GetClassRoomTeacherDTO>(_mapper.ConfigurationProvider).ToListAsync();
            var result = PaginateHelper<GetClassRoomTeacherDTO>.Paginate(data, totalCount, paginateRequestDTO);
            return result;
        }

        public async Task<bool> IsUserTeacherAsync(int classId, string userId)
        {
            return await _context.ClassRooms.AnyAsync(e => e.Id == classId && e.TeacherId == userId);
        }

        public async Task<bool> IsUserTeacherByExamIdAsync(int examId, string teacherId)
        {
            var classId = await _context.Exams.Where(e => e.Id == examId).Select(e => e.ClassId).SingleOrDefaultAsync();
            return await _context.ClassRooms.AnyAsync(e => e.Id == classId && e.TeacherId == teacherId);
        }
    }
}
