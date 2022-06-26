namespace VetApp.DataAccess.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<VeterinaryVisit> VeterinaryVisit { get; set; }
        public List <Pet> Pet { get; set; }

    }
}
