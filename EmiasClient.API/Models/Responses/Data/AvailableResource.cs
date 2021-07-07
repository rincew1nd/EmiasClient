using System.Text.Json.Serialization;

namespace EmiasClient.API.Models.Responses.Data
{
    public class AvailableResource
    {
        /// <summary>
        /// Врач, кабинет, поликлинника
        /// </summary>
        [JsonPropertyName("availableResource")]
        public DoctorInfo SpecialityInfo { get; set; }
        
        /// <summary>
        /// Расписание с доступными временными интервалами
        /// </summary>
        public ScheduleOfDay[] ScheduleOfDay { get; set; }
    }
}