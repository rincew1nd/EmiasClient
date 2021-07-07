using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using EmiasClient.API.Helpers;
using EmiasClient.API.Models.Requests;
using EmiasClient.API.Models.Requests.Params;
using EmiasClient.API.Models.Responses;

namespace EmiasClient.API
{
    public class Client
    {
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public Client(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<CheckOmsInfoResponse> CheckOmsInfoAsync(CheckOmsInfoRequest request)
        {
            return await ExecuteRequest<CheckOmsInfoRequest, CheckOmsInfoResponse>(request);
        }
        
        public async Task<GetSpecialitiesInfoResponse> GetSpecialitiesInfoAsync(GetSpecialitiesInfoRequest request)
        {
            return await ExecuteRequest<GetSpecialitiesInfoRequest, GetSpecialitiesInfoResponse>(request);
        }
        
        public async Task<GetDoctorsInfoResponse> GetDoctorsInfoAsync(GetDoctorsInfoRequest request)
        {
            return await ExecuteRequest<GetDoctorsInfoRequest, GetDoctorsInfoResponse>(request);
        }
        
        public async Task<GetAvailableResourceScheduleInfoResponse> GetAvailableResourceScheduleInfoAsync(GetAvailableResourceScheduleInfoRequest request)
        {
            return await ExecuteRequest<GetAvailableResourceScheduleInfoRequest, GetAvailableResourceScheduleInfoResponse>(request);
        }

        public async Task<CreateAppointmentResponse> CreateAppointmentAsync(CreateAppointmentRequest request)
        {
            return await ExecuteRequest<CreateAppointmentRequest, CreateAppointmentResponse>(request);
        }
        
        public async Task<ShiftAppointmentResponse> ShiftAppointmentAsync(ShiftAppointmentRequest request)
        {
            return await ExecuteRequest<ShiftAppointmentRequest, ShiftAppointmentResponse>(request);
        }
        
        public async Task<CancelAppointmentResponse> CancelAppointmentAsync(CancelAppointmentRequest request)
        {
            return await ExecuteRequest<CancelAppointmentRequest, CancelAppointmentResponse>(request);
        }
        
        private async Task<T2> ExecuteRequest<T1, T2>(T1 request)
        {
            var attribute = AttributeHelper.GetAttribute<T1, EndpointAttribute>();
            using var httpClient = new HttpClient {BaseAddress = new Uri(_baseUrl)};
            var json = JsonSerializer.Serialize(request, _jsonSerializerOptions);
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await httpClient.PostAsync(attribute.Endpoint, content);
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T2>(responseJson, _jsonSerializerOptions);
        }
    }
}