using EmiasClient.API.Helpers;
using EmiasClient.API.Models.Requests.Params;
using EmiasClient.API.Models.Responses;

namespace EmiasClient.API.Models.Requests
{
    /// <summary>
    /// Запрос информации о доступных к записи врачах
    /// </summary>
    [Endpoint("/api/new/eip2/?getDoctorsInfo")]
    public class GetDoctorsInfoRequest : BaseRequest<GetDoctorInfo>
    {
        /// <inheritdoc/>
        public override string Method { get; protected set; } = "getDoctorsInfo";
    }
}