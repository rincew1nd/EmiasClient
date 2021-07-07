using System.Text.Json.Serialization;
using EmiasClient.API.Helpers;

namespace EmiasClient.API.Models.Requests
{
    /// <summary>
    /// Базовый запрос JsonRpcV2
    /// </summary>
    public abstract class BaseRequest<T1>
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
        public string RequestId { get; } = Generators.GenerateJsonRpcV2Id();
        
        /// <summary>
        /// Название метода
        /// </summary>
        [JsonIgnore]
        public abstract string Method { get; protected set; }
        
        /// <summary>
        /// Параметры запроса в формате <see cref="T1"/>
        /// </summary>
        [JsonPropertyName("params")]
        public T1 Param { get; set; }
    }
}