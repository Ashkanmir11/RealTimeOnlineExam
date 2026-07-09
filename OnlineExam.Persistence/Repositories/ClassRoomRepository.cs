using OnlineExam.Application.Contracts.Persistence;
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
        private readonly OnlineExamDbContext _dbContext;
        public ClassRoomRepository(OnlineExamDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
