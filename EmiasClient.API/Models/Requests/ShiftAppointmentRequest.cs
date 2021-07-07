using EmiasClient.API.Helpers;
using EmiasClient.API.Models.Requests.Params;
using EmiasClient.API.Models.Responses;

namespace EmiasClient.API.Models.Requests
{
    /// <summary>
    /// Перенос записи ко врачу
    /// </summary>
    [Endpoint("/api/new/eip2/?shiftAppointment")]
    public class ShiftAppointmentRequest : BaseRequest<ShiftAppointment>
    {
        /// <inheritdoc/>
        public override string Method { get; protected set; } = "shiftAppointment";
    }
}