using System;

namespace EmiasClient.API.Models.Requests.Params
{
    /// <summary>
    /// Специальность врача и данные ОМС
    /// </summary>
    public class GetDoctorInfo : OmsData
    {
        /// <summary>
        /// Идентификатор специальности
        /// </summary>
        public string SpecialityId { get; set; }
        
        /// <summary>
        /// .ctor
        /// </summary>
        public GetDoctorInfo() { }

        /// <summary>
        /// .ctor
        /// </summary>
        public GetDoctorInfo(string number, DateTime birthDate, string specialityId)
            : base(number, birthDate)
        {
            SpecialityId = specialityId;
        }
    }
}