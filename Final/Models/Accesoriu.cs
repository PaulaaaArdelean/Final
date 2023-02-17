namespace Final.Models
{
    public class Accesoriu
    {
        public int ID { get; set; }
        public string Accesoriul { get; set; }
        public ICollection<AccesoriuRochie>? AccesoriiRochii { get; set; }
    }
}
