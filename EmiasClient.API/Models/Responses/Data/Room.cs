using System;
using System.Text.Json.Serialization;

namespace EmiasClient.API.Models.Responses.Data
{
    /// <summary>
    /// Полный адрес поликлинники и номер кабинета
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Номер кабинета
        /// </summary>
        public string Number { get; set; }
        
        /// <summary>
        /// Идентификатор адреса
        /// </summary>
        public long AddressPointId { get; set; }
        
        /// <summary>
        /// Адрес
        /// </summary>
        public string DefaultAddress { get; set; }
        
        /// <summary>
        /// Ближайшая доступная дата к записи
        /// </summary>
        public DateTime AvailabilityDate { get; set; }
        
        /// <summary>
        /// Идентификатор лечебно-профилактического учреждения
        /// </summary>
        [JsonPropertyName("lpuId")]
        public long ClinicId { get; set; }
        
        /// <summary>
        /// Название лечебно-профилактического учреждения
        /// </summary>
        [JsonPropertyName("lpuShortName")]
        public string ClinicName { get; set; }
    }
}