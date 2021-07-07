using System;

namespace EmiasClient.API.Models.Requests.Params
{
    /// <summary>
    /// Доступное время врача
    /// </summary>
    public class GetAvailableResourceScheduleInfo : OmsData
    {
        /// <summary>
        /// Идентификатор врача
        /// </summary>
        public long AvailableResourceId { get; set; }
        
        /// <summary>
        /// .ctor
        /// </summary>
        public GetAvailableResourceScheduleInfo() { }

        /// <summary>
        /// .ctor
        /// </summary>
        public GetAvailableResourceScheduleInfo(string number, DateTime birthDate, long availableResourceId)
            : base(number, birthDate)
        {
            AvailableResourceId = availableResourceId;
        }
    }
}