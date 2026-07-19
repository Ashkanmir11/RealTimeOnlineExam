using OnlineExam.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers
{
    public class CreateMultipleChoiceAnswerDTO : CreateCommonAnswerDTO
    {
        public int? StudentChoice { get; set; }
        public int MultipleChoiceQuestionId { get; set; }
    }
}
