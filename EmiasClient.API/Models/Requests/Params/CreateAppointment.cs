using System;
using EmiasClient.API.Models.Responses.Data;

namespace EmiasClient.API.Models.Requests.Params
{
    /// <summary>
    /// Создание записи ко врачу
    /// </summary>
    public class CreateAppointment : GetAvailableResourceScheduleInfo
    {
        /// <summary>
        /// Идентификатор помещения
        /// </summary>
        public long ComplexResourceId { get; set; }
        
        /// <summary>
        /// Тип приёма
        /// </summary>
        public string ReceptionTypeId { get; set; }
        
        /// <summary>
        /// Дата начала приёма
        /// </summary>
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// Дата конца приёма
        /// </summary>
        public DateTime EndTime { get; set; }
        
        public CreateAppointment() { }

        public CreateAppointment(string number, DateTime date, long availableResourceId, long complexResourceId, string receptionTypeId, DateTime startTime, DateTime endTime)
            : base(number, date, availableResourceId)
        {
            ComplexResourceId = complexResourceId;
            ReceptionTypeId = receptionTypeId;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}