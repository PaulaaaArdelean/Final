using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace Final.Models
{
    public class Marime
    {
        public int ID { get; set; }
        //@"^[XXS]+[XS]+[S]+[M]+[L]+[XL]+[XXL]*$
        [RegularExpression(@"(XXS|XS|S|M|L|XL|XXL)$", ErrorMessage = "Marimile disponibile sunt doar XXS, XS, S, M, L, XL si XXL")]

        public string Marimea { get; set; }
        public ICollection<Rochie>? Rochii { get; set; }
    }
}
