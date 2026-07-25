using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IMultipleChoiceAnswersRepository:IGenericRepository<MultipleChoiceAnswers>
    {
        Task<MultipleChoiceAnswers> GetByQuestionIdAsync(int questionId);
        Task<GetMultipleChoiceAnswerStudentDTO> GetForStudent(string studentId,int  questionId);

    }
}
