using System;

namespace EmiasClient.API.Models.Requests.Params
{
    /// <summary>
    /// Отмена записи ко врачу
    /// </summary>
    public class CancelAppointment : OmsData
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public long AppointmentId { get; set; }
        
        /// <summary>
        /// .ctor
        /// </summary>
        public CancelAppointment() { }

        /// <summary>
        /// .ctor
        /// </summary>
        public CancelAppointment(string number, DateTime birthDate, long appointmentId)
            : base(number, birthDate)
        {
            AppointmentId = appointmentId;
        }
    }
}