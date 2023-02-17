using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final.Data;
using Final.Models;
using Final.Models.ViewModels;

namespace Final.Pages.Designeri
{
    public class IndexModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public IndexModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

        public IList<Designer> Designer { get;set; } = default!;

        public DesignerIndexData DesignerData { get; set; }
        public int DesignerID { get; set; }
        public int RochieID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            DesignerData = new DesignerIndexData();
            DesignerData.Designeri = await _context.Designer
            .Include(i => i.Rochii)
            // .ThenInclude(c => c.Author)
            .OrderBy(i => i.NumeDesigner)
            .ToListAsync();
            if (id != null)
            {
                DesignerID = id.Value;
                Designer publisher = DesignerData.Designeri
                .Where(i => i.ID == id.Value).Single();
                DesignerData.Rochii = publisher.Rochii;
            }

        }
    }
}
