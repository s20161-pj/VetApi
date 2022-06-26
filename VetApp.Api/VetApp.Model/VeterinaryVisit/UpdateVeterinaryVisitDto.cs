using VetApp.DataAccess.Models;

namespace VetApp.Model.VeterinaryVisit
{
    public class UpdateVeterinaryVisitDto
    {
        public int Id { get; set; }
        public TypeOfVisit TypeOfVisit { get; set; } = TypeOfVisit.Diagnostics;
        public DateTime DateOfVisit { get; set; }
        public int VetId { get; set; }
        public int ClientId { get; set; }
    }
}
