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

namespace Final.Pages.Imprumuturi
{
    

    public class IndexModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public IndexModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

        public IList<Imprumut> Imprumut { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Imprumut != null)
            {
                Imprumut = await _context.Imprumut
                .Include(i => i.Rochie)
                    .ThenInclude(i => i.Designer)
                .Include(i => i.Clienta)
                .ToListAsync();
            }
        }
    }
}
