using System;
using System.Globalization;
using System.Text.Json;
using System.Threading.Tasks;
using EmiasClient.API;
using EmiasClient.API.Models.Requests;
using EmiasClient.API.Models.Requests.Params;
using EmiasClient.API.Models.Responses;
using EmiasClient.API.Models.Responses.Data;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace EmailClient.Test
{
    public class ClientTest
    {
        private string _omsNumber;
        private DateTime _birthDate;

        public ClientTest()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _omsNumber = config["OmsNumber"];
            _birthDate = DateTime.ParseExact(config["BirthDate"], "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }
        
        [Fact]
        public async Task CheckLoginTest()
        {
            var request = new CheckOmsInfoRequest()
            {
                Param = new OmsData(_omsNumber, _birthDate)
            };
            var client = new Client("https://emias.info");
            var result = await client.CheckOmsInfoAsync(request);
            Assert.Null(result.Error);
        }

        [Fact]
        public async Task GetSpecialitiesInfoTest()
        {
            var request = new GetSpecialitiesInfoRequest()
            {
                Param = new OmsData(_omsNumber, _birthDate)
            };
            var client = new Client("https://emias.info");
            var result = await client.GetSpecialitiesInfoAsync(request);
            Assert.Null(result.Error);
        }

        [Fact]
        public async Task GetDoctorsInfoTest()
        {
            var request = new GetDoctorsInfoRequest()
            {
                Param = new GetDoctorInfo(_omsNumber, _birthDate, "2011")
            };
            var client = new Client("https://emias.info");
            var result = await client.GetDoctorsInfoAsync(request);
            Assert.Null(result.Error);
        }

        [Fact]
        public async Task GetAvailableResourceScheduleInfoTest()
        {
            var request = new GetAvailableResourceScheduleInfoRequest()
            {
                Param = new GetAvailableResourceScheduleInfo(_omsNumber, _birthDate, 19114495)
            };
            var client = new Client("https://emias.info");
            var result = await client.GetAvailableResourceScheduleInfoAsync(request);
            Assert.Null(result.Error);
        }

        //[Fact]
        //public async Task CreateAppointmentTest()
        //{
        //    var request = new CreateAppointmentRequest()
        //    {
        //        Param = new CreateAppointment(
        //            OmsNumber,
        //            BirthDate,
        //            19114495,
        //            193442588,
        //            "1801",
        //            new DateTime(2021, 06, 22, 17, 25, 00),
        //            new DateTime(2021, 06, 22, 17, 30, 00)
        //        )
        //    };
        //    var client = new Client("https://emias.info");
        //    var result = await client.CreateAppointmentAsync(request);
        //}
        //
        //[Fact]
        //public async Task CancelAppointmentTest()
        //{
        //    var request = new CancelAppointmentRequest()
        //    {
        //        Param = new CancelAppointment(
        //            OmsNumber,
        //            BirthDate,
        //            322367285773
        //        )
        //    };
        //    var client = new Client("https://emias.info");
        //    var result = await client.CancelAppointmentAsync(request);
        //}
    }
}