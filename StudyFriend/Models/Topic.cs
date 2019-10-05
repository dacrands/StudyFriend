using System.Collections.Generic;

namespace StudyFriend.Models
{
    public class Topic
    {
        public int TopicID { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
