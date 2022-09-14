using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyJourney.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "An app to help you study";
        }
    }
}
