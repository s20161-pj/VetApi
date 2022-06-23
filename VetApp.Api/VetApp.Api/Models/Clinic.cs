namespace VetApp.Api.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Vet> Vets { get; set; }
    }
}
