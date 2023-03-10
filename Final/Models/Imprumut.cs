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
        public DateTime DataImpumutare { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataReturnare { get; set; }
    }
}
