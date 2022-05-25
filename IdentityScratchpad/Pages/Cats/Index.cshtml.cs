using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityScratchpad.Data;
using IdentityScratchpad.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IdentityScratchpad.Areas.Identity.Data;

namespace IdentityScratchpad.Pages.Cats
{
    [Authorize(Policy = "Lucky")]
    public class IndexModel : PageModel
    {
        private readonly IdentityScratchpadDbContext _context;
        private readonly UserManager<CustomUser> _userManager;


        public IndexModel(IdentityScratchpadDbContext context, 
            UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Cat> Cat { get;set; } = default!;
        public int? LuckyNumber { get; set; }

        public async Task OnGetAsync()
        {
            bool isFavorite27 = User.HasClaim("LuckyNumber", "27");
            bool isAdmin = User.HasClaim(c => c.Type == "Admin");

            this.LuckyNumber = User.Claims
                .Where(c => c.Type == "LuckyNumber")
                .Select(c => int.Parse(c.Value))
                .FirstOrDefault();


            string userId = _userManager.GetUserId(User);

            CustomUser customUser = _context.Users
                .Include(u => u.Cats)
                .First(x => x.Id == userId);

            Cat = customUser.Cats;

            //CustomUser user = _userManager.GetUserAsync(User).Result;

            //if (_context.Cats != null)
            //{
            //    Cat = await _context.Cats
            //    .Include(c => c.Owner)
            //    .Where(c => c.OwnerId == userId)
            //    .ToListAsync();
            //}
        }
    }
}
