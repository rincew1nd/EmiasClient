using System;

namespace EmiasClient.API.Models.Responses.Data
{
    /// <summary>
    /// Временные интервалы
    /// </summary>
    public class Slot
    {
        /// <summary>
        /// Дата начала приёма
        /// </summary>
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// Дата конца приёма
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}