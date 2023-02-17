namespace Final.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string Categoria { get; set; }
        public ICollection<Rochie>? Rochii { get; set; }
    }
}
