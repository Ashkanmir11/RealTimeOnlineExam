using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.MultipleChoiceAnswers
{
    public class GetMultipleChoiceAnswerStudentDTO 
    {
        public int Id {  get; set; }
        public int? StudentChoice { get; set; }
    }
}
