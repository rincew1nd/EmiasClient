using System.Collections.Generic;
using EmiasClient.API.Models.Responses.Data;

namespace EmiasClient.API.Models.Responses
{
    /// <summary>
    /// Запрос информации о доступных к записи специальностях
    /// </summary>
    public class GetSpecialitiesInfoResponse : BaseResponse<IEnumerable<SpecialityInfo>> { }
}