using EmiasClient.API.Helpers;
using EmiasClient.API.Models.Requests.Params;
using EmiasClient.API.Models.Responses;

namespace EmiasClient.API.Models.Requests
{
    /// <summary>
    /// Запрос информации о доступных к записи специальностях
    /// </summary>
    [Endpoint("/api/new/eip2/?getSpecialitiesInfo")]
    public class GetSpecialitiesInfoRequest : BaseRequest<OmsData>
    {
        /// <inheritdoc/>
        public override string Method { get; protected set; } = "getSpecialitiesInfo";
    }
}