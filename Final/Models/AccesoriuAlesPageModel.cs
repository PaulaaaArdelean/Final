using Final.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;

namespace Final.Models
{
    public class AccesoriuAlesPageModel : PageModel
    {
        public List<AccesoriuAles> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(FinalContext context,
        Rochie rochie)
        {
            var allCategories = context.Accesoriu;
            var bookCategories = new HashSet<int>(rochie.AccesoriiRochii.Select(c => c.AccesoriuID)); //
            AssignedCategoryDataList = new List<AccesoriuAles>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AccesoriuAles
                {
                    AccesoriuID = cat.ID,
                    NumeAccesoriu = cat.Accesoriul,
                    Ales = bookCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(FinalContext context,
        string[] selectedCategories, Rochie bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.AccesoriiRochii = new List<AccesoriuRochie>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (bookToUpdate.AccesoriiRochii.Select(c => c.Accesoriu.ID));
            foreach (var cat in context.Accesoriu)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.AccesoriiRochii.Add(
                        new AccesoriuRochie
                        {
                            RochieID = bookToUpdate.ID,
                            AccesoriuID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        AccesoriuRochie courseToRemove
                        = bookToUpdate
                        .AccesoriiRochii
                        .SingleOrDefault(i => i.AccesoriuID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
