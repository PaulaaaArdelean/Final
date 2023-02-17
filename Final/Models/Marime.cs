namespace Final.Models
{
    public class Marime
    {
        public int ID { get; set; }

        public string Marimea { get; set; }
        public ICollection<Rochie>? Rochii { get; set; }
    }
}
