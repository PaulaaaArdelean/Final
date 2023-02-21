using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Final.Models
{
    public class Clienta
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula (ex.Ana sau Ana Maria sau AnaMaria) si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3, ErrorMessage ="Acest camp trebuie sa contina minim 3 caractere")]
        [Display(Name = "Numele clientei")]

        public string? NumeClienta { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula si poate contine doar litere")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Acest camp trebuie sa contina minim 3 caractere")]
        [Display(Name = "Prenumele clientei")]

        public string? PrenumeClienta { get; set; }

        [StringLength(70, ErrorMessage ="Acest camp poate contine maxim 70 caractere")]
        public string? Adresa { get; set; }
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Numarul de telefon trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        public string? Telefon { get; set; }
        [Display(Name = "Nume Intreg")]
        public string? NumeIntreg
        {
            get
            {
                return NumeClienta + " " + PrenumeClienta;
            }
        }
        public ICollection<Imprumut>? Imprumuturi { get; set; }
    }
}
