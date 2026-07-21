using MediatR;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands
{
    public class UpdateTrueOrFalseAnswerTeacherRequest : IRequest
    {
        public required UpdateTrueOrFalseAnswerTeacherDTO? UpdateTrueOrFalseAnswerTeacherDTO { get; set; }
        public int ExamId {  get; set; }
    }
}
