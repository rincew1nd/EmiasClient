using System.Text.Json.Serialization;
using EmiasClient.API.Helpers;
using EmiasClient.API.Models.Responses.Data;

namespace EmiasClient.API.Models.Responses
{
    /// <summary>
    /// Базовый ответ JsonRpcV2
    /// </summary>
    public abstract class BaseResponse<T>
    {
        /// <summary>
        /// Версия JsonRpcV2
        /// </summary>
        [JsonPropertyName("jsonrpc")]
        public string JsonRpcVersion { get; } = "2.0";
        
        /// <summary>
        /// Идентификатор запроса
        /// </summary>
        [JsonPropertyName("id")]
        public string RequestId { get; }
        
        /// <summary>
        /// Результат запроса в формате <see cref="T"/>
        /// </summary>
        [JsonPropertyName("result")]
        public T Result { get; set; }
        
        /// <summary>
        /// Описание ошибки
        /// </summary>
        [JsonPropertyName("error")]
        public ErrorResponse Error { get; set; }
    }
}