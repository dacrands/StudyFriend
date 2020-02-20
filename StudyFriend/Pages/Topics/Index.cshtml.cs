using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using StudyFriend.Data;
using StudyFriend.Models;


namespace StudyFriend.Pages.Topics
{
    public class IndexModel : PageModel
    {
        private readonly StudyFriendContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(StudyFriendContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public IList<Topic> Topic { get; set; }
        
        public async Task OnGetAsync()
        {
            var currUser = await _userManager.GetUserAsync(User);
            var topics = from t in _context.Topic
                         select t;
            topics = topics
                        .Where(t => t.UserId == currUser.Id)
                        .OrderBy(t => t.Name);
            Topic = await topics.ToListAsync();
        }
    }
}
