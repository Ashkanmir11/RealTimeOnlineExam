using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class Question
    {
        public string? QuestionText {  get; set; }
        public string? CurrectAnswer {  get; set; }
        public string? StudentAnswer {  get; set; }
        public int? TotalScore { get; set; }
        public int? StudnetScore { get; set; }
        //Relations
        public int? QuestionTypeId {  get; set; }
        public QuestionType? QuestionType { get; set; }
        //TOdo
        //add exam realtion
    }
}
