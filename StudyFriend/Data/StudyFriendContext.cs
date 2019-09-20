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

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Topic> Topic { get; set; }
    }
}
