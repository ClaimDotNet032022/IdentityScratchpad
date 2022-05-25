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
    public class DetailsModel : PageModel
    {
        private readonly IdentityScratchpadDbContext _context;

        public DetailsModel(IdentityScratchpadDbContext context)
        {
            _context = context;
        }

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
    }
}
