using EmiasClient.API.Helpers;
using EmiasClient.API.Models.Requests.Params;
using EmiasClient.API.Models.Responses;

namespace EmiasClient.API.Models.Requests
{
    /// <summary>
    /// Запрос информации о доступных времени врача
    /// </summary>
    [Endpoint("/api/new/eip2/?getAvailableResourceScheduleInfo")]
    public class GetAvailableResourceScheduleInfoRequest : BaseRequest<GetAvailableResourceScheduleInfo>
    {
        /// <inheritdoc/>
        public override string Method { get; protected set; } = "getAvailableResourceScheduleInfo";
    }
}