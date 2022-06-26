namespace VetApp.DataAccess.Models;

public class VeterinaryVisit
{
    public int Id { get; set; }
    public TypeOfVisit Class { get; set; } = TypeOfVisit.Diagnostics;
    public DateTime DateOfVisit { get; set; }
    public int VetId { get; set; }
    public int ClientId { get; set; }
    public Vet Vet { get; set; }
    public Client Client { get; set; }
}