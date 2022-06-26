namespace VetApp.DataAccess.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nip { get; set; }
        public string Address { get; set; }
        public List<Vet> Vets { get; set; }
    }
}
