using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
<<<<<<<< HEAD:src/StudyFriend/Pages/Topics/Details.cshtml.cs
using StudyFriend.Data;
using StudyFriend.Models;
========
using StudyJourney.Data;
using StudyJourney.Models;
>>>>>>>> develop:src/StudyJourney/Pages/Topics/Details.cshtml.cs
using System.Threading.Tasks;

namespace StudyJourney.Pages.Topics
{
    public class DetailsModel : PageModel
    {
        private readonly StudyFriendContext _context;

        public DetailsModel(StudyFriendContext context)
        {
            _context = context;
        }

        public Topic Topic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Topic = await _context.Topic
                .Include(t => t.Questions)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TopicID == id);

            if (Topic == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
