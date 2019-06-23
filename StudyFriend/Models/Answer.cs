using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyFriend.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public int QuestionID { get; set; }
        public string Body { get; set; }
        public Question Question { get; set; }
    }
}
