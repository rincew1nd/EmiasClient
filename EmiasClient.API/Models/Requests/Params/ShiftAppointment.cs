namespace EmiasClient.API.Models.Requests.Params
{
    /// <summary>
    /// Перенос записи ко врачу
    /// </summary>
    public class ShiftAppointment : CreateAppointment
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public string AppointmentId { get; set; }
    }
}