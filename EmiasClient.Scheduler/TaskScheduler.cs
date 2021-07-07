using System;
using System.Collections.Generic;
using EmiasClient.Scheduler.Models;

namespace EmiasClient.Scheduler
{
    public class TaskScheduler
    {
        private BaldurToolkit.Cron.TaskScheduler _taskScheduler;
        private Dictionary<Guid, TaskRunner> _tasks;

        public TaskScheduler()
        {
            _taskScheduler = new BaldurToolkit.Cron.TaskScheduler();
            _taskScheduler.TaskExecutionFail += (e, v) => { LogException(v.Exception); };
            _tasks = new Dictionary<Guid, TaskRunner>();
        }

        public void ScheduleTask(ScheduledTaskParameters taskParameters)
        {
            if (_tasks.ContainsKey(taskParameters.Id))
            {
                throw new InvalidOperationException("Задача уже запланирована");
            }
            
            var task = new TaskRunner(taskParameters);
            _tasks.Add(taskParameters.Id, task);
            
            _taskScheduler.RemoveTask(taskParameters.Id.ToString());
            _taskScheduler.ScheduleCronTask(
                taskParameters.Id.ToString(),
                "* * * * *",//"*/5 * * * *",
                async () => await task.RunTask()
            );
        }

        public bool StopTask(Guid id)
        {
            if (_tasks.ContainsKey(id))
            {
                _tasks.Remove(id);
                return _taskScheduler.RemoveTask(id.ToString());
            }
            throw new InvalidOperationException($"Задача с идентификатором {id.ToString()} не найдена");
        }

        private void LogException(Exception ex)
        {
            Console.WriteLine($"[{DateTime.Now:dd-MM-yyyy HH:mm:ss}] Error happened.\nMessage - {ex.Message}\nStackTrace - {ex.StackTrace}");
        }
    }
}