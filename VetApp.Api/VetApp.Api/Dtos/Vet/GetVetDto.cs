namespace VetApp.Api.Dtos.Vet;

public class GetVetDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? OccupationNumber { get; set; }
    public int ClinicId { get; set; }
}
