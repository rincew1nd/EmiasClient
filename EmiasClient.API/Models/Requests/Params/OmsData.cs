using System;
using System.Text.Json.Serialization;

namespace EmiasClient.API.Models.Requests.Params
{
    /// <summary>
    /// Данные ОМС
    /// </summary>
    public class OmsData
    {
        /// <summary>
        /// Номер полиса ОМС
        /// </summary>
        [JsonPropertyName("omsNumber")]
        public string Number { get; set; }
        
        /// <summary>
        /// Дата рождения в формате 'yyyy-MM-dd'
        /// </summary>
        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; }

        /// <summary>
        /// .ctor
        /// </summary>
        public OmsData() { }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="number">Номер полиса ОМС</param>
        /// <param name="birthDate">Дата рождения</param>
        public OmsData(string number, DateTime birthDate)
        {
            Number = number;
            BirthDate = birthDate.ToString("yyyy-MM-dd");
        }
    }
}