using System.Text.Json.Serialization;

namespace EmiasClient.API.Models.Responses.Data
{
    public class Doctor
    {
        [JsonPropertyName("employeeId")]
        public long Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        
        public long SpecialityId { get; set; }
        public string SpecialityName { get; set; }

        public string GetDoctorInfo()
        {
            return $"{SpecialityName} | {FirstName} {LastName} {SecondName}";
        }
    }
}