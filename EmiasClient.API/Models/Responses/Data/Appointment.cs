namespace EmiasClient.API.Models.Responses.Data
{
    /// <summary>
    /// Краткая информация о записи
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public long AppointmentId { get; set; }
        
        /// <summary>
        /// Название записи
        /// </summary>
        public string AppointmentNumber { get; set; }
    }
}