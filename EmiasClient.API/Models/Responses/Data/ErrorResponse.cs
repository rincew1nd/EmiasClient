using System;

namespace EmiasClient.API.Models.Responses.Data
{
    public class ErrorResponse
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public long Code { get; set; }
        
        /// <summary>
        /// Описание ошибки
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// Эксепшен
        /// </summary>
        public EmiasException Exception { get; set; }
        
        public class EmiasException : Exception
        {
            public string Code { get; set; }
            public string Exception { get; set; }
            public string ExceptionType { get; set; }
            public string SoapException { get; set; }
        }
    }
}