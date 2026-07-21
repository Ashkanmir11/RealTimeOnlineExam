using MediatR;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands
{
    public class UpdateMultipleChoiceAnswerTeacherRequest : IRequest
    {
        public required UpdateMultipleChoiceAnswerTeacherDTO UpdateMultipleChoiceAnswerTeacherDTO { get; set; }
        public int ExamId { get; set; }
    }
}
