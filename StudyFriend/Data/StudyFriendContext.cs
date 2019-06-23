using Microsoft.EntityFrameworkCore;

namespace StudyFriend.Models
{
    public class StudyFriendContext : DbContext
    {
        public StudyFriendContext (DbContextOptions<StudyFriendContext> options)
            : base(options)
        {
        }

        public DbSet<StudyFriend.Models.Question> Question { get; set; }
        public DbSet<StudyFriend.Models.Answer> Answer { get; set; }
        public DbSet<StudyFriend.Models.Topic> Topic { get; set; }
    }
}
