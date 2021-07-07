using System;

namespace EmiasClient.API.Models.Responses.Data
{
    /// <summary>
    /// Расписание с доступными временными интервалами
    /// </summary>
    public class ScheduleOfDay
    {
        /// <summary>
        /// Дата приёма
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Расписание приёма
        /// </summary>
        public ScheduleBySlot[] ScheduleBySlot { get; set; }
    }
}