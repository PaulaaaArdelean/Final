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

namespace Final.Pages.Accesorii
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
      public Accesoriu Accesoriu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Accesoriu == null)
            {
                return NotFound();
            }

            var accesoriu = await _context.Accesoriu.FirstOrDefaultAsync(m => m.ID == id);

            if (accesoriu == null)
            {
                return NotFound();
            }
            else 
            {
                Accesoriu = accesoriu;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Accesoriu == null)
            {
                return NotFound();
            }
            var accesoriu = await _context.Accesoriu.FindAsync(id);

            if (accesoriu != null)
            {
                Accesoriu = accesoriu;
                _context.Accesoriu.Remove(Accesoriu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
