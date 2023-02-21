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
    public class IndexModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public IndexModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

        public IList<Rochie> Rochie { get;set; } = default!;
      
        public RochieData RochieD { get; set; }
        public int RochieID { get; set; }
        public int AccesoriuID { get; set; }
       
       public string DenumireSort { get; set; }
        public string PretCresc { get; set; }
        public string PretDesc { get; set; }
        public string CurrentFilter { get; set; }
        
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            RochieD = new RochieData();

            PretCresc = String.IsNullOrEmpty(sortOrder) ? "pret_cresc" : "";
            PretDesc = String.IsNullOrEmpty(sortOrder) ? "pret_desc" : "";
            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "denumire_desc" : "";
            CurrentFilter = searchString;


            RochieD.Rochii = await _context.Rochie
            .Include(b => b.Designer)
            .Include(b => b.Categorie)
            .Include(b => b.Marime)
            .Include(b => b.AccesoriiRochii)
            .ThenInclude(b => b.Accesoriu)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();


                    if (!String.IsNullOrEmpty(searchString))
                    {
                        RochieD.Rochii = RochieD.Rochii.Where(s => s.Denumire.Contains(searchString)
                                              
                        || s.Marime.Marimea.Contains(searchString)
                        ||s.Categorie.Categoria.Contains(searchString)
                       || s.Designer.NumeDesigner.Contains(searchString)
                      || s.Denumire.Contains(searchString));
                    }


         

            if (id != null)
                {
                    RochieID = id.Value;
                    Rochie book = RochieD.Rochii
                    .Where(i => i.ID == id.Value).Single();
                    RochieD.Accesorii = book.AccesoriiRochii.Select(s => s.Accesoriu);
                }

                switch (sortOrder)
                {
                    case "denumire_desc":
                        RochieD.Rochii = RochieD.Rochii.OrderByDescending(s => s.Denumire);
                        break;

                    case "pret_desc":
                        RochieD.Rochii = RochieD.Rochii.OrderByDescending(s => s.Pret);
                        break;
                     case "pret_cresc":
                    RochieD.Rochii = RochieD.Rochii.OrderBy(s =>
                    s.Pret);
                       break;

            }

            // case "pret_cresc":
            //RochieD.Rochii = RochieD.Rochii.OrderBy(s =>
            //s.Pret);
            //   break;

            //public async Task OnGetAsync()
            //     {
            //       if (_context.Rochie != null)
            //     {
            //       Rochie = await _context.Rochie
            //         .Include(r=>r.Designer)
            //        .Include(r => r.Marime)
            //      .Include(r=>r.Categorie)
            //   .ToListAsync();
            //}
            //}

        }
    }
}
