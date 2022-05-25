using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdentityScratchpad.Data;
using IdentityScratchpad.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace IdentityScratchpad.Pages.Cats
{
    [Authorize("Administrator")]
    public class CreateModel : PageModel
    {
        private readonly IdentityScratchpadDbContext _context;

        public CreateModel(IdentityScratchpadDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "UserName");
            return Page();
        }

        [BindProperty]
        public Cat Cat { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cats == null || Cat == null)
            {
                return Page();
            }

            _context.Cats.Add(Cat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
