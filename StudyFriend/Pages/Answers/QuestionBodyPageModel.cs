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
            object selectedQuestion = null, int questionID = 0)
        {
            var questionsQuery = from q in _context.Question
                                orderby q.Body
                                select q;
            
            if (questionID != 0)
            {
                QuestionBodySL = new SelectList(questionsQuery.AsNoTracking(),
                "QuestionID", "Body", questionID);
                return;
            }

            QuestionBodySL = new SelectList(questionsQuery.AsNoTracking(),
                "QuestionID", "Body", selectedQuestion);
        }
    }
}
