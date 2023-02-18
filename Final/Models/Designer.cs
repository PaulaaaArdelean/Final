using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class Designer
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele designerului trebuie sa inceapa cu majuscula si poate contine doar litere")]

        public string NumeDesigner { get; set; }
        public ICollection<Rochie>? Rochii { get; set; }
    }
}
