using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Models;

namespace Final.Pages.Cliente
{
    public class DeleteModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public DeleteModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Clienta Clienta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clienta == null)
            {
                return NotFound();
            }

            var clienta = await _context.Clienta.FirstOrDefaultAsync(m => m.ID == id);

            if (clienta == null)
            {
                return NotFound();
            }
            else 
            {
                Clienta = clienta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Clienta == null)
            {
                return NotFound();
            }
            var clienta = await _context.Clienta.FindAsync(id);

            if (clienta != null)
            {
                Clienta = clienta;
                _context.Clienta.Remove(Clienta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
