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

namespace Final.Pages.Rochii
{
    public class EditModel : AccesoriuAlesPageModel
    {
        private readonly Final.Data.FinalContext _context;

        public EditModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rochie Rochie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rochie == null)
            {
                return NotFound();
            }


            // punctul 15 de la pagina 34
            Rochie = await _context.Rochie
                .Include(r => r.Designer)
                .Include(r => r.AccesoriiRochii).ThenInclude(r => r.Accesoriu)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);



            //  var rochie =  await _context.Rochie.FirstOrDefaultAsync(m => m.ID == id);
            if (Rochie == null)
            {
                return NotFound();
            }
            //  Rochie = rochie;

            //tot de la pasul 15 pag 34
            PopulateAssignedCategoryData(_context, Rochie);


            ViewData["DesignerID"] = new SelectList(_context.Set<Designer>(), "ID",
           "NumeDesigner");

            ViewData["MarimeID"] = new SelectList(_context.Set<Marime>(), "ID",
          "Marimea");

            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID",
         "Categoria");


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var bookToUpdate = await _context.Rochie
            .Include(i => i.Designer)
            .Include(i => i.AccesoriiRochii)
            .ThenInclude(i => i.Accesoriu)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Rochie>(
            bookToUpdate,
            "Rochie",
            i => i.Denumire, i => i.Pret,
            i => i.DesignerID, i => i.MarimeID, i => i.CategorieID))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care 
            //este editata 
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();

        }
    }
}
