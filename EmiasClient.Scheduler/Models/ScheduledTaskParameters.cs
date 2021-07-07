using System;

namespace EmiasClient.Scheduler.Models
{
    public class ScheduledTaskParameters
    {
        /// <summary>
        /// Идентификатор таски
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Название таски
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Номер полиса ОМС клиента
        /// </summary>
        public string OmsNumber { get; set; }
        
        /// <summary>
        /// Дата рождения клиента
        /// </summary>
        public DateTime Birthday { get; set; }
        
        /// <summary>
        /// Минимальная дата для записи (записать не раньше чем за % времени)
        /// </summary>
        public TimeSpan? MinTimeSpan { get; set; }
        
        /// <summary>
        /// Максимальная дата для записи (записать не позже чем за % времени)
        /// </summary>
        public TimeSpan? MaxTimeSpan { get; set; }
        
        /// <summary>
        /// Перестать пытаться записаться на приём после даты
        /// </summary>
        public DateTime? LastPossibleDate { get; set; }
        
        /// <summary>
        /// Запись после N времени (если не указано, искать записи без ограничения по начальному времени)
        /// </summary>
        public TimeSpan? MinAppointmentTime { get; set; }
        
        /// <summary>
        /// Запись до N времени (если не указано, искать записи без ограничения по конечному времени)
        /// </summary>
        public TimeSpan? MaxAppointmentTime { get; set; }
        
        /// <summary>
        /// Искать докторов с указанной специальностью
        /// </summary>
        public string SpecialityId { get; set; }
        
        /// <summary>
        /// Искать только в указанных поликлинниках
        /// </summary>
        public long[] LpuIds { get; set; }
        
        /// <summary>
        /// Искать только указанных докторов
        /// </summary>
        public long[] DoctorIds { get; set; }
    }
}