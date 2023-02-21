using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Final.Pages.Cliente
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public EditModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clienta Clienta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clienta == null)
            {
                return NotFound();
            }

            var clienta =  await _context.Clienta.FirstOrDefaultAsync(m => m.ID == id);
            if (clienta == null)
            {
                return NotFound();
            }
            Clienta = clienta;
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

            _context.Attach(Clienta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientaExists(Clienta.ID))
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

        private bool ClientaExists(int id)
        {
          return _context.Clienta.Any(e => e.ID == id);
        }
    }
}
