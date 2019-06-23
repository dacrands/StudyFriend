using System.Collections.Generic;

namespace StudyFriend.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public int TopicID { get; set; }
        public string Body { get; set; }
        public Topic Topic { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
