using System;
using System.Globalization;
using System.Threading.Tasks;
using EmiasClient.Scheduler.Models;
using Microsoft.Extensions.Configuration;
using Xunit;
using TaskScheduler = EmiasClient.Scheduler.TaskScheduler;

namespace EmailClient.Test
{
    public class TempRunner
    {   
        private string _omsNumber;
        private DateTime _birthDate;

        public TempRunner()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _omsNumber = config["TestData:OmsNumber"];
            _birthDate = DateTime.ParseExact(config["TestData:BirthDate"], "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }
        
        [Fact]
        public async Task Test()
        {
            var scheduler = new TaskScheduler();
            scheduler.ScheduleTask(new ScheduledTaskParameters()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                OmsNumber = _omsNumber,
                Birthday = _birthDate,
                SpecialityId = "112",
                //LpuIds = new[] { 8299143654, 10000254 },
                //DoctorIds = new[] { 10008173L },
                MinTimeSpan = new TimeSpan(2, 0, 0),
                MaxTimeSpan = new TimeSpan(90, 0, 0),
                MinAppointmentTime = new TimeSpan(9, 0, 0),
                MaxAppointmentTime = new TimeSpan(14, 0, 0)
            }, (log) => Console.WriteLine(log));
            await Task.Delay(new TimeSpan(8, 0, 0));
        }
    }
}