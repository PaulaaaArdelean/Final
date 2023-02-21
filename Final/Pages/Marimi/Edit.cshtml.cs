﻿using System;
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

namespace Final.Pages.Marimi
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
        public Marime Marime { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Marime == null)
            {
                return NotFound();
            }

            var marime =  await _context.Marime.FirstOrDefaultAsync(m => m.ID == id);
            if (marime == null)
            {
                return NotFound();
            }
            Marime = marime;
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

            _context.Attach(Marime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarimeExists(Marime.ID))
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

        private bool MarimeExists(int id)
        {
          return _context.Marime.Any(e => e.ID == id);
        }
    }
}
