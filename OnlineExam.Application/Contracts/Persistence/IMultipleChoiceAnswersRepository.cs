using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IMultipleChoiceAnswersRepository : IGenericRepository<MultipleChoiceAnswers>
    {
        Task<MultipleChoiceAnswers> GetByQuestionIdAsync(int questionId);
        Task<GetMultipleChoiceAnswerStudentDTO> GetForStudent(string studentId, int questionId);
        Task<bool> IsAnswerExist(string studentId, int questionId);

    }
}
