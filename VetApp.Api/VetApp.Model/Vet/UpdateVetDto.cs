namespace VetApp.Model.Vet
{
    public class UpdateVetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string OccupationNumber { get; set; }
        public int ClinicId { get; set; }
    }
}
