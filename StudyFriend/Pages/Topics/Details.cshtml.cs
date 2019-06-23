using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyFriend.Models;

namespace StudyFriend.Pages.Topics
{
    public class DetailsModel : PageModel
    {
        private readonly StudyFriend.Models.StudyFriendContext _context;

        public DetailsModel(StudyFriend.Models.StudyFriendContext context)
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

            Topic = await _context.Topic.FirstOrDefaultAsync(m => m.ID == id);

            if (Topic == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
