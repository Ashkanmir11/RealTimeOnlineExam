using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IDescriptiveAnswersRepository : IGenericRepository<DescriptiveAnswers>
    {
        Task<DescriptiveAnswers> GetByQuestionIdAsync(int questionId);
        Task<GetDescriptiveAnswerStudentDTO> GetForStudent(string studentId,int questionId);  
        Task<bool> IsAnswerExist(string studentId, int questionId);

    }
}
