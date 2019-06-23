﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyFriend.Models;

namespace StudyFriend.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly StudyFriend.Models.StudyFriendContext _context;

        public IndexModel(StudyFriend.Models.StudyFriendContext context)
        {
            _context = context;
        }

        public IList<Question> Question { get;set; }

        public async Task OnGetAsync()
        {
            Question = await _context.Question
                .Include(q => q.Topic)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
