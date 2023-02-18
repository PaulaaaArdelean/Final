using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final.Data;
using Final.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Final.Pages.Rochii
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : AccesoriuAlesPageModel
    {
        private readonly Final.Data.FinalContext _context;

        public CreateModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DesignerID"] = new SelectList(_context.Set<Designer>(), "ID",
          "NumeDesigner");

            ViewData["MarimeID"] = new SelectList(_context.Set<Marime>(), "ID",
        "Marimea");

            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID",
          "Categoria");
            
            var book = new Rochie();
            book.AccesoriiRochii = new List<AccesoriuRochie>();
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        [BindProperty]
        public Rochie Rochie { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Rochie();
            if (selectedCategories != null)
            {
                newBook.AccesoriiRochii = new List<AccesoriuRochie>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new AccesoriuRochie
                    {
                        AccesoriuID = int.Parse(cat)
                    };
                    newBook.AccesoriiRochii.Add(catToAdd);
                }
            }
            Rochie.AccesoriiRochii = newBook.AccesoriiRochii;
            _context.Rochie.Add(Rochie);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }
    }
}
