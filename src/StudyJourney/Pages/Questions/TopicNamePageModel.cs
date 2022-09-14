using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
<<<<<<<< HEAD:src/StudyFriend/Pages/Questions/TopicNamePageModel.cs
using StudyFriend.Data;
========
using StudyJourney.Data;
>>>>>>>> develop:src/StudyJourney/Pages/Questions/TopicNamePageModel.cs
using System.Linq;
using System.Security.Claims;

namespace StudyJourney.Pages.Questions
{
    public class TopicNamePageModel : PageModel
    {
        public SelectList TopicNameSL { get; set; }

        public void PopulateTopicsDropDownList(StudyFriendContext _context,
            object selectedTopic = null)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var topicsQuery = from t in _context.Topic
                              where t.UserId == userId
                              orderby t.Name
                              select t;
            TopicNameSL = new SelectList(topicsQuery.AsNoTracking(),
                "TopicID", "Name", selectedTopic);
        }
    }
}
