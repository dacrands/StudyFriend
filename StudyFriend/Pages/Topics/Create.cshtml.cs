using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyFriend.Models;
using StudyFriend.Data;
using Microsoft.AspNetCore.Identity;

namespace StudyFriend.Pages.Topics
{
    public class CreateModel : PageModel
    {
        private readonly StudyFriendContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(StudyFriendContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Topic Topic { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currUser = await _userManager.GetUserAsync(User);

            Topic.UserId = currUser.Id;

            _context.Topic.Add(Topic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}