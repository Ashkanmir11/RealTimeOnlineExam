using OnlineExam.Ui.DTO.Common;
using OnlineExam.Ui.DTO.DescriptiveAnswers;
using OnlineExam.Ui.DTO.DescriptiveQuestion;
using OnlineExam.Ui.DTO.MultipleChoiceQuestion;
using OnlineExam.Ui.DTO.TrueOrFalseAnswers;
using OnlineExam.Ui.DTO.TrueOrFalseQuestion;
using OnlineExam.Ui.DTO.MultipleChoiceAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineExam.Ui.DTO.Question
{
    public class GetQuestionStudentDTO : BaseDTO
    {
        public string? QuestionText { get; set; }
        public decimal TotalScore { get; set; }
        public GetTrueOrFalseQuestionStudentDTO? TrueOrFalseQuestion { get; set; }
        public GetDescriptiveQuestionStudentDTO? DescriptiveQuestion { get; set; }
        public GetMultipleChoiceQuestionStudentDTO? MultipleChoiceQuestion { get; set; }
        public GetTrueOrFalseAnswerStudentDTO? TrueOrFalseAnswer { get; set; }
        public GetDescriptiveAnswerStudentDTO? DescriptiveAnswer { get; set; }
        public GetMultipleChoiceAnswerStudentDTO? MultipleChoiceAnswer { get;set; }
    }
}
