﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using StudyFriend.Data;
using StudyFriend.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudyFriend.Pages.Topics
{
    public class IndexModel : PageModel
    {
        private readonly StudyFriendContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(StudyFriendContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public IList<Topic> Topic { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        public async Task OnGetAsync()
        {
            var currUser = await _userManager.GetUserAsync(User);
            var topics = from t in _context.Topic
                         where t.UserId == currUser.Id
                         select t;           

            if (!string.IsNullOrEmpty(SearchString))
            {
                topics = topics.Where(s => s.Name.Contains(SearchString));
            }

            Topic = await topics.ToListAsync();
        }
    }
}
