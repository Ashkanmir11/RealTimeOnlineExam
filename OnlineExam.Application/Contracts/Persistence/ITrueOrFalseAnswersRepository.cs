using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface ITrueOrFalseAnswersRepository : IGenericRepository<TrueOrFalseAnswers>
    {
        Task<TrueOrFalseAnswers> GetByQuestionIdAsync(int questionId);
    }
}
