using VetApp.DataAccess.Models;

namespace VetApp.Model.VeterinaryVisit
{
    public class GetVeterinaryVisitDto
    {
        public int Id { get; set; }
        public TypeOfVisit Class { get; set; } = TypeOfVisit.Diagnostics;
        public DateTime DateOfVisit { get; set; }
        public int VetId { get; set; }
        public int ClientId { get; set; }
    }
}
