using System.Text.Json.Serialization;

namespace VetApp.DataAccess.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeOfVisit
    {
        Vaccination,
        Diagnostics
    }
}