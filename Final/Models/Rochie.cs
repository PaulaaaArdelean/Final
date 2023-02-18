using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Xml.Linq;

namespace Final.Models
{
    public class Rochie
    {
        public int ID { get; set; }

        [Display(Name = "Denumirea rochiei")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Denumirea rochiei trebuie sa inceapa cu majuscula")]

        public string Denumire { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 100000, ErrorMessage ="Pretul nu poate fi mai mic de 0.01 RON sau mai mare de 100000 RON")]
        public decimal Pret { get; set; }
        
        public int? DesignerID { get; set; }
        public Designer? Designer { get; set; }

        public int? MarimeID { get; set; }
        public Marime? Marime { get; set; }

        public int? CategorieID { get; set; }
        public Categorie? Categorie { get; set; }

     public ICollection<AccesoriuRochie>? AccesoriiRochii { get; set; }
    }
}
