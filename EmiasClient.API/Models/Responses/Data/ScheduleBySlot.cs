using System.Text.Json.Serialization;

namespace EmiasClient.API.Models.Responses.Data
{
    /// <summary>
    /// Расписание приёма
    /// </summary>
    public class ScheduleBySlot
    {
        /// <summary>
        /// Номер кабинета
        /// </summary>
        [JsonPropertyName("cabinetNumber")]
        public string RoomNumber { get; set; }
        
        /// <summary>
        /// Идентификатор ресурса
        /// </summary>
        public long ComplexResourceId { get; set; }
        
        /// <summary>
        /// Доступные временные интервалы
        /// </summary>
        public Slot[] Slot { get; set; }
    }
}