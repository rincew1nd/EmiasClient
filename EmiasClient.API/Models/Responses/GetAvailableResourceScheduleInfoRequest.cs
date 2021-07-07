using System.Collections.Generic;
using EmiasClient.API.Models.Responses.Data;

namespace EmiasClient.API.Models.Responses
{
    /// <summary>
    /// Запрос информации о доступных времени врача
    /// </summary>
    public class GetAvailableResourceScheduleInfoResponse : BaseResponse<AvailableResource> { }
}