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
    public class IndexModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public IndexModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

        public IList<Marime> Marime { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Marime != null)
            {
                Marime = await _context.Marime.ToListAsync();
            }
        }
    }
}
