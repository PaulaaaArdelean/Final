using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Models;

namespace Final.Pages.Marimi
{
    public class DetailsModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public DetailsModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

      public Marime Marime { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Marime == null)
            {
                return NotFound();
            }

            var marime = await _context.Marime.FirstOrDefaultAsync(m => m.ID == id);
            if (marime == null)
            {
                return NotFound();
            }
            else 
            {
                Marime = marime;
            }
            return Page();
        }
    }
}
