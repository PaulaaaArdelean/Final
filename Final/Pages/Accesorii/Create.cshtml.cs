using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final.Data;
using Final.Models;

namespace Final.Pages.Accesorii
{
    public class CreateModel : PageModel
    {
        private readonly Final.Data.FinalContext _context;

        public CreateModel(Final.Data.FinalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Accesoriu Accesoriu { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Accesoriu.Add(Accesoriu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
