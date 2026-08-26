using MediatR;
using OnlineExam.Application.Contracts.AIServices;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Features.Exam.Request.Commands;
namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class EndExamRequestHandler : IRequestHandler<EndExamRequest>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAuthServices _authServices;
        private readonly ITrueOrFalseAnswersRepository _trueOrFalseAnswersRepository;
        private readonly IMultipleChoiceAnswersRepository _multipleChoiceAnswersRepository;
        private readonly IDescriptiveAnswersRepository _descriptiveAnswersRepository;
        private readonly IAiServices _aiServices;
        private readonly IExamAttamptRepository _examAttamptRepository;
        public EndExamRequestHandler(IQuestionRepository questionRepository, IAuthServices authServices, ITrueOrFalseAnswersRepository trueOrFalseAnswersRepository
            , IMultipleChoiceAnswersRepository multipleChoiceAnswersRepository, IDescriptiveAnswersRepository descriptiveAnswersRepository
            , IAiServices aiServices, IExamAttamptRepository examAttamptRepository)
        {
            _questionRepository = questionRepository;
            _authServices = authServices;
            _trueOrFalseAnswersRepository = trueOrFalseAnswersRepository;
            _multipleChoiceAnswersRepository = multipleChoiceAnswersRepository;
            _descriptiveAnswersRepository = descriptiveAnswersRepository;
            _aiServices = aiServices;
            _examAttamptRepository = examAttamptRepository;
        }
        public async Task Handle(EndExamRequest request, CancellationToken cancellationToken)
        {
            string currentUserId;
            currentUserId = request.StudentId == null ? await _authServices.GetCurrentUserIdAsync() : request.StudentId;
            var examEnded = await _examAttamptRepository.ExamEndedAsync(request.ExamId, currentUserId);
            if (!examEnded)
            {
                await _examAttamptRepository.EndExamAsync(request.ExamId, currentUserId);
                var questionList = await _questionRepository.GetByExamIdAsync<GetQuestionTeacherDTO>(request.ExamId, false, currentUserId, new DTOs.Common.PaginateRequestDTO() { PageCount = 999999, PageNumber = 1 });
                //Automatic Grading
                foreach (var question in questionList.Data)
                {
                    if (question.TrueOrFalseQuestion != null)
                    {
                        var answer = await _trueOrFalseAnswersRepository.GetByQuestionIdAsync(question.TrueOrFalseQuestion.Id);
                        if (answer != null)
                        {
                            if (answer.StudentAnswer == question.TrueOrFalseQuestion.CorrectAnswer)
                            {
                                answer.StudentScore = question.TotalScore;
                            }
                            await _trueOrFalseAnswersRepository.UpdateAsync(answer.Id, answer);
                        }
                    }
                    if (question.MultipleChoiceQuestion != null)
                    {
                        var answer = await _multipleChoiceAnswersRepository.GetByQuestionIdAsync(question.MultipleChoiceQuestion.Id);
                        if (answer != null)
                        {
                            if (answer.StudentChoice == question.MultipleChoiceQuestion.CorrectChoice)
                            {
                                answer.StudentScore = question.TotalScore;
                            }
                            await _multipleChoiceAnswersRepository.UpdateAsync(answer.Id, answer);
                        }
                    }
                    else if (question.DescriptiveQuestion != null)
                    {
                        var answer = await _descriptiveAnswersRepository.GetByQuestionIdAsync(question.DescriptiveQuestion.Id);
                        if (answer != null)
                        {
                            var score = await _aiServices.GetScoreAsync(answer.StudentAnswer, question.DescriptiveQuestion.CorrectAnswer, question.TotalScore);
                            answer.StudentScore = score;
                            await _descriptiveAnswersRepository.UpdateAsync(answer.Id, answer);
                        }
                    }
                }
            }
        }
    }
}
