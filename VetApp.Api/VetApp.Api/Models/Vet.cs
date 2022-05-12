namespace VetApp.Api.Models;

public class Vet
{
    public int Id { get; set; }
    public string Name { get; set; } = "Asia";
    public string Surname { get; set; } = "W";
    public string OccupationNumber { get; set; } = "xxx";
    public int ClinicId { get; set; }
}