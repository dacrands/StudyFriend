using StudyFriend.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StudyFriend.Pages.Questions
{
    public class TopicNamePageModel : PageModel
    {
        public SelectList TopicNameSL { get; set; }

        public void PopulateTopicsDropDownList(StudyFriendContext _context,
            object selectedTopic = null)
        {
            var topicsQuery = from t in _context.Topic
                              orderby t.Name
                              select t;

            TopicNameSL = new SelectList(topicsQuery.AsNoTracking(),
                "ID", "Name", selectedTopic);
        }
    }
}
