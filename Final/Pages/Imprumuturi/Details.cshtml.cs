using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Models;

namespace Final.Pages.Imprumuturi
{
    public class DetailsModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public DetailsModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

      public Imprumut Imprumut { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Imprumut == null)
            {
                return NotFound();
            }

            var imprumut = await _context.Imprumut.FirstOrDefaultAsync(m => m.ID == id);
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
    }
}
