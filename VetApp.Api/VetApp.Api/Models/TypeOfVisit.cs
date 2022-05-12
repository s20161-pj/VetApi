using System.Text.Json.Serialization;

namespace VetApp.Api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeOfVisit
    {
        Vaccination,
        Diagnostics
    }
}