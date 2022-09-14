using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
<<<<<<<< HEAD:src/StudyFriend/Pages/Answers/Index.cshtml.cs
using StudyFriend.Data;
using StudyFriend.Models;
========
using StudyJourney.Data;
using StudyJourney.Models;
>>>>>>>> develop:src/StudyJourney/Pages/Answers/Index.cshtml.cs
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyJourney.Pages.Answers
{
    public class IndexModel : PageModel
    {
        private readonly StudyFriendContext _context;

        public IndexModel(StudyFriendContext context)
        {
            _context = context;
        }

        public IList<Answer> Answer { get; set; }

        public async Task OnGetAsync()
        {
            Answer = await _context.Answer
                .Include(a => a.Question).ToListAsync();
        }
    }
}
