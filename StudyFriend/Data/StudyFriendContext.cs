using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
