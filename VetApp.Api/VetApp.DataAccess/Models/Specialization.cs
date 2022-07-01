namespace VetApp.DataAccess.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Vet> Vets { get; set; }
    }
}
