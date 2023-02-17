namespace Final.Models
{
    public class RochieData
    {
        public IEnumerable<Rochie> Rochii { get; set; }
        public IEnumerable<Accesoriu> Accesorii { get; set; }
        public IEnumerable<AccesoriuRochie> AccesoriiRochii { get; set; }
    }
}
