using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyFriend.Models;

namespace StudyFriend.Pages.Questions
{
    public class CreateModel : TopicNamePageModel
    {
        private readonly StudyFriend.Models.StudyFriendContext _context;

        public CreateModel(StudyFriend.Models.StudyFriendContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? topicId)
        {
            if (topicId != null)
            {
                PopulateTopicsDropDownList(_context, topicId);
                return Page();
            }
            PopulateTopicsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyQuestion = new Question();

            if (await TryUpdateModelAsync<Question>(
                emptyQuestion,
                "question",
                s => s.QuestionID, s => s.TopicID, s => s.Body, s => s.Topic))
            {
                _context.Question.Add(emptyQuestion);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Questions/Details", new { id = emptyQuestion.QuestionID });
            }

            PopulateTopicsDropDownList(_context, emptyQuestion.QuestionID);
            return Page();
        }
    }
}