using AutoMapper;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Persistence.Repositories
{
    public class ClassRoomMembersRepository : GenericRepository<ClassRoomMembers>, IClassRoomMembersRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public ClassRoomMembersRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
    }
}
