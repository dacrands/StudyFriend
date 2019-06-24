using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyFriend.Models;

namespace StudyFriend.Pages.Answers
{
    public class EditModel : QuestionBodyPageModel
    {
        private readonly StudyFriend.Models.StudyFriendContext _context;

        public EditModel(StudyFriend.Models.StudyFriendContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Answer Answer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Answer = await _context.Answer
                .Include(a => a.Question).FirstOrDefaultAsync(m => m.AnswerID == id);

            if (Answer == null)
            {
                return NotFound();
            }

            PopulateQuestionsDropDownList(_context, Answer.QuestionID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var answerToUpdate = await _context.Answer.FindAsync(id);

            if (await TryUpdateModelAsync<Answer>(
                answerToUpdate,
                "answer",
                a => a.Body, a => a.QuestionID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("../Questions/Details", new { id = answerToUpdate.QuestionID });
            }

            PopulateQuestionsDropDownList(_context, answerToUpdate.QuestionID);
            return Page();
        }        
    }
}
