using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Final.Pages.Imprumuturi
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public DeleteModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Imprumut Imprumut { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Imprumut == null)
            {
                return NotFound();
            }

            var imprumut = await _context.Imprumut
                   .Include(i => i.Rochie)
                    .ThenInclude(i => i.Designer)
                .Include(i => i.Clienta).FirstOrDefaultAsync(m => m.ID == id);

            if (imprumut == null)
            {
                return NotFound();
            }
            else 
            {
                Imprumut = imprumut;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Imprumut == null)
            {
                return NotFound();
            }
            var imprumut = await _context.Imprumut.FindAsync(id);

            if (imprumut != null)
            {
                Imprumut = imprumut;
                _context.Imprumut.Remove(Imprumut);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
