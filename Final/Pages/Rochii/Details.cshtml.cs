using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Models;

namespace Final.Pages.Rochii
{
    public class DetailsModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public DetailsModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

      public Rochie Rochie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rochie == null)
            {
                return NotFound();
            }

            var rochie = await _context.Rochie
                .Include(r=>r.AccesoriiRochii).ThenInclude(b => b.Accesoriu)
                .Include(r=>r.Categorie)
                .Include(r => r.Designer)
                .Include(r => r.Marime)

                .FirstOrDefaultAsync(m => m.ID == id);
            if (rochie == null)
            {
                return NotFound();
            }
            else 
            {
                Rochie = rochie;
            }
            return Page();
        }
    }
}
