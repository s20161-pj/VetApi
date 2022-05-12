namespace VetApp.Api.Models;

public class VeterinaryVisit
{
    public int Id { get; set; }
    public TypeOfVisit Class { get; set; } = TypeOfVisit.Diagnostics;
}