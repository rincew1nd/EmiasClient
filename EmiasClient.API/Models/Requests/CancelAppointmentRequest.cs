using EmiasClient.API.Helpers;
using EmiasClient.API.Models.Requests.Params;
using EmiasClient.API.Models.Responses;

namespace EmiasClient.API.Models.Requests
{
    /// <summary>
    /// Отмена записи ко врачу
    /// </summary>
    [Endpoint("/api/new/eip2/?cancelAppointment")]
    public class CancelAppointmentRequest : BaseRequest<CancelAppointment>
    {
        /// <inheritdoc/>
        public override string Method { get; protected set; } = "cancelAppointment";
    }
}