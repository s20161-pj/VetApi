namespace VetApp.DataAccess.Models;

public class Vet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string OccupationNumber { get; set; }
    public int ClinicId { get; set; }
    public Clinic Clinic { get; set; }
    public List<VeterinaryVisit> VeterinaryVisit { get; set; }
    public List<Specialization> Specialization { get; set; }

}