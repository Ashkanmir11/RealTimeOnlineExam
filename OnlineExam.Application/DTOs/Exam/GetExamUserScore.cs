using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Exam
{
    public class GetExamUserScore
    {
        public GetUserDTO? User {  get; set; }
        public List<GetQuestionDTO>? Questions { get; set; }


    }
}
