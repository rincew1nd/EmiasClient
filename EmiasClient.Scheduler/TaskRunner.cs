﻿using System;
using System.Linq;
using System.Threading.Tasks;
using EmiasClient.API;
using EmiasClient.API.Models.Requests;
using EmiasClient.API.Models.Requests.Params;
using EmiasClient.API.Models.Responses.Data;
using EmiasClient.Scheduler.Models;

namespace EmiasClient.Scheduler
{
    public class TaskRunner
    {
        private readonly Client _client;
        private readonly ScheduledTaskParameters _parameters;

        public TaskRunner(ScheduledTaskParameters parameters)
        {
            _client = new Client("https://emias.info/");
            _parameters = parameters;
        }

        public async Task RunTask()
        {
            if ((_parameters.LastPossibleDate.HasValue && _parameters.LastPossibleDate > DateTime.Now) ||
                !_parameters.LastPossibleDate.HasValue)
            {
                var doctorInfos = await _client.GetDoctorsInfoAsync(new GetDoctorsInfoRequest()
                {
                    Param = new GetDoctorInfo(_parameters.OmsNumber, _parameters.Birthday, _parameters.SpecialityId)
                });
                if (doctorInfos.Error != null)
                {
                    throw new ApplicationException(doctorInfos.Error.Message);
                }

                var doctors = doctorInfos.Result
                    .Where(
                        ar => ((_parameters?.LpuIds?.Contains(ar.LpuId) ?? false) ||
                               _parameters.LpuIds?.Length == null) &&
                              ((_parameters?.DoctorIds?.Contains(ar.Doctor.Id) ?? false) ||
                               _parameters.DoctorIds?.Length == null)
                    )
                    .ToList();

                foreach (var doctor in doctors)
                {
                    var availableResources = await _client.GetAvailableResourceScheduleInfoAsync(new GetAvailableResourceScheduleInfoRequest()
                    {
                        Param = new GetAvailableResourceScheduleInfo(_parameters.OmsNumber, _parameters.Birthday, doctor.Id)
                    });
                    foreach (var availableResource in availableResources.Result.ScheduleOfDay)
                    {
                        if (_parameters.LastPossibleDate.HasValue && availableResource.Date > _parameters.LastPossibleDate)
                        {
                            continue;
                        }

                        if (_parameters.MinTimeSpan.HasValue &&
                            DateTime.Now.Add(_parameters.MinTimeSpan.Value).Date > availableResource.Date)
                        {
                            continue;
                        }
                        if (_parameters.MaxTimeSpan.HasValue &&
                            DateTime.Now.Add(_parameters.MaxTimeSpan.Value).Date < availableResource.Date)
                        {
                            continue;
                        }
                        
                        foreach (var scheduleBySlot in availableResource.ScheduleBySlot)
                        {
                            foreach (var slot in scheduleBySlot.Slot)
                            {
                                if (_parameters.MinTimeSpan.HasValue &&
                                    DateTime.Now.Add(_parameters.MinTimeSpan.Value) > slot.StartTime)
                                {
                                    continue;
                                }
                                if (_parameters.MaxTimeSpan.HasValue &&
                                    DateTime.Now.Add(_parameters.MaxTimeSpan.Value) < slot.EndTime)
                                {
                                    continue;
                                }
                                
                                if (_parameters.MinAppointmentTime.HasValue &&
                                    slot.StartTime.TimeOfDay < _parameters.MinAppointmentTime)
                                {
                                    continue;
                                }
                                if (_parameters.MaxAppointmentTime.HasValue &&
                                    slot.StartTime.TimeOfDay > _parameters.MaxAppointmentTime)
                                {
                                    continue;
                                }
                                NotificateUser(slot, availableResources.Result);
                            }
                        }
                    }
                }
            }
        }

        private void NotificateUser(Slot slot, AvailableResource resource)
        {
            Console.WriteLine($"[{DateTime.Now:dd-MM-yyyy HH:mm:ss}] {resource.SpecialityInfo.SpecialityName} | {resource.SpecialityInfo.Doctor.GetDoctorInfo()} | Доступно время {slot.StartTime} - {slot.EndTime}");
        }
    }
}