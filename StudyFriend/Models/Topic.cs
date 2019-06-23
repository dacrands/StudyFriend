using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyFriend.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
