using StudyFriend.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StudyFriend.Pages.Answers
{
    public class QuestionBodyPageModel : PageModel
    {
        public SelectList QuestionBodySL { get; set; }

        public void PopulateQuestionsDropDownList(StudyFriendContext _context,
            object selectedQuestion = null)
        {
            var questionsQuery = from q in _context.Question
                                orderby q.Body
                                select q;

            QuestionBodySL = new SelectList(questionsQuery.AsNoTracking(),
                "QuestionID", "Body", selectedQuestion);
        }
    }
}
