using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
<<<<<<<< HEAD:src/StudyFriend/Pages/Questions/Index.cshtml.cs
using StudyFriend.Data;
using StudyFriend.Models;
========
using StudyJourney.Data;
using StudyJourney.Models;
>>>>>>>> develop:src/StudyJourney/Pages/Questions/Index.cshtml.cs
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudyJourney.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly StudyFriendContext _context;

        public IndexModel(StudyFriendContext context)
        {
            _context = context;
        }

        public IList<Question> Question { get; set; }

        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var questionsQuery = from q in _context.Question
                                 join t in _context.Topic
                                 on q.TopicID equals t.TopicID
                                 where t.UserId == userId
                                 select q;

            Question = await questionsQuery
                .Include(q => q.Topic)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
