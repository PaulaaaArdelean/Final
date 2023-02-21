using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class Imprumut
    {
        public int ID { get; set; }
        public int? ClientaID { get; set; }
        public Clienta? Clienta { get; set; }
        public int? RochieID { get; set; }
        public Rochie? Rochie { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Data imprumutarii")]
        public DateTime DataImpumutare { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data returnarii")]

        public DateTime DataReturnare { get; set; }
    }
}
