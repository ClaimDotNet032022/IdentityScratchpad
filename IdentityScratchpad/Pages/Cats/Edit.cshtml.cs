using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityScratchpad.Data;
using IdentityScratchpad.Data.Entities;

namespace IdentityScratchpad.Pages.Cats
{
    public class EditModel : PageModel
    {
        private readonly IdentityScratchpadDbContext _context;

        public EditModel(IdentityScratchpadDbContext context)
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

            var cat =  await _context.Cats.FirstOrDefaultAsync(m => m.Id == id);
            if (cat == null)
            {
                return NotFound();
            }
            Cat = cat;
           ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatExists(Cat.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CatExists(int id)
        {
          return (_context.Cats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
