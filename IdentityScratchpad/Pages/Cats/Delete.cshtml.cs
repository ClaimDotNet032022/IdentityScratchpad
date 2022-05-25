using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityScratchpad.Data;
using IdentityScratchpad.Data.Entities;

namespace IdentityScratchpad.Pages.Cats
{
    public class DeleteModel : PageModel
    {
        private readonly IdentityScratchpadDbContext _context;

        public DeleteModel(IdentityScratchpadDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cat Cat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cats == null)
            {
                return NotFound();
            }

            var cat = await _context.Cats.FirstOrDefaultAsync(m => m.Id == id);

            if (cat == null)
            {
                return NotFound();
            }
            else 
            {
                Cat = cat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cats == null)
            {
                return NotFound();
            }
            var cat = await _context.Cats.FindAsync(id);

            if (cat != null)
            {
                Cat = cat;
                _context.Cats.Remove(Cat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
