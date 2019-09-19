using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudyFriend.Models
{
    public class StudyFriendContext : IdentityDbContext<ApplicationUser>
    {
        public StudyFriendContext (DbContextOptions<StudyFriendContext> options)
            : base(options)
        {
        }

        public DbSet<StudyFriend.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<StudyFriend.Models.Question> Question { get; set; }
        public DbSet<StudyFriend.Models.Answer> Answer { get; set; }
        public DbSet<StudyFriend.Models.Topic> Topic { get; set; }
    }
}
