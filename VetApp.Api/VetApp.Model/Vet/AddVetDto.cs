namespace VetApp.Model.Vet;

public class AddVetDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string OccupationNumber { get; set; }
    public int ClinicId { get; set; }
    public List<int> SpecializationIds { get; set; }
}