namespace Final.Models
{
    public class AccesoriuRochie
    {
        public int ID { get; set; }
        public int RochieID { get; set; }
        public Rochie Rochie { get; set; }

        public int AccesoriuID { get; set; }
        public Accesoriu Accesoriu { get; set; }
    }
}
