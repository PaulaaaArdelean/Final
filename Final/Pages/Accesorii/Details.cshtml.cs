using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Models;

namespace Final.Pages.Accesorii
{
    public class DetailsModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public DetailsModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

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
    }
}
