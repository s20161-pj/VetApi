namespace VetApp.Api.Models;

public class Vet
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Surname { get; set; } 
    public string OccupationNumber { get; set; } 
    public int ClinicId { get; set; }
}