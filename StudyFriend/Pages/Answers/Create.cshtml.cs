using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyFriend.Models;

namespace StudyFriend.Pages.Answers
{
    public class CreateModel : QuestionBodyPageModel
    {
        private readonly StudyFriend.Models.StudyFriendContext _context;

        public CreateModel(StudyFriend.Models.StudyFriendContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateQuestionsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Answer Answer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyAnswer = new Answer();

            if (await TryUpdateModelAsync<Answer>(
                emptyAnswer,
                "answer",
                s => s.AnswerID, s => s.QuestionID, s => s.Body, s => s.Question))
            {
                _context.Answer.Add(emptyAnswer);
                await _context.SaveChangesAsync();                
                return RedirectToPage("./Index");
            }

            PopulateQuestionsDropDownList(_context, emptyAnswer.AnswerID);
            return Page();
        }
    }
}