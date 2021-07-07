using System.Text.Json.Serialization;

namespace EmiasClient.API.Models.Responses.Data
{
    /// <summary>
    /// Специальность врача и данные ОМС
    /// </summary>
    public class DoctorInfo
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Идентификатор специальности
        /// </summary>
        [JsonPropertyName("arSpecialityId")]
        public long SpecialityId { get; set; }
        
        /// <summary>
        /// Название специальности
        /// </summary>
        [JsonPropertyName("arSpecialityName")]
        public string SpecialityName { get; set; }
        
        public ComplexResource[] ComplexResource { get; set; }
        
        public ReceptionType[] ReceptionType { get; set; }
        
        [JsonPropertyName("mainDoctor")]
        public Doctor Doctor { get; set; }
        
        /// <summary>
        /// Идентификатор лечебно-профилактического учреждения
        /// </summary>
        public long LpuId { get; set; }
    }
}