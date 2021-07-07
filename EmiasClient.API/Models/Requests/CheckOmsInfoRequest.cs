using EmiasClient.API.Helpers;
using EmiasClient.API.Models.Requests.Params;
using EmiasClient.API.Models.Responses;

namespace EmiasClient.API.Models.Requests
{
    /// <summary>
    /// Проверка номера ОМС и даты рождения на валидность
    /// </summary>
    [Endpoint("/api/new/eip2/?getReferralsInfo")]
    public class CheckOmsInfoRequest : BaseRequest<OmsData>
    {
        public override string Method { get; protected set; } = "getReferralsInfo";
    }
}