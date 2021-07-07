using EmiasClient.API.Helpers;
using EmiasClient.API.Models.Requests.Params;
using EmiasClient.API.Models.Responses;

namespace EmiasClient.API.Models.Requests
{
    /// <summary>
    /// Создание записи ко врачу
    /// </summary>
    [Endpoint("/api/new/eip2/?createAppointment")]
    public class CreateAppointmentRequest : BaseRequest<CreateAppointment>
    {
        /// <inheritdoc/>
        public override string Method { get; protected set; } = "createAppointment";
    }
}