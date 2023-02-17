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

namespace Final.Pages.Accesorii
{
    public class EditModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public EditModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Accesoriu Accesoriu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Accesoriu == null)
            {
                return NotFound();
            }

            var accesoriu =  await _context.Accesoriu.FirstOrDefaultAsync(m => m.ID == id);
            if (accesoriu == null)
            {
                return NotFound();
            }
            Accesoriu = accesoriu;
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

            _context.Attach(Accesoriu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccesoriuExists(Accesoriu.ID))
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

        private bool AccesoriuExists(int id)
        {
          return _context.Accesoriu.Any(e => e.ID == id);
        }
    }
}
