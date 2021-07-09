using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public void ScheduleTask(ScheduledTaskParameters taskParameters, Action<string> logAction)
        {
            if (_tasks.ContainsKey(taskParameters.Id))
            {
                throw new InvalidOperationException("Задача уже запланирована");
            }
            
            var task = new TaskRunner(taskParameters, logAction);
            _tasks.Add(taskParameters.Id, task);
            
            _taskScheduler.RemoveTask(taskParameters.Id.ToString());
            _taskScheduler.ScheduleCronTask(
                taskParameters.Id.ToString(),
                "* * * * *",
                async () => await task.RunTask()
            );
            
            logAction($"[{DateTime.Now.ToString()}] Отслеживание мест запущено");
        }

        public bool StopTask(Guid id, Action<string> logAction)
        {
            if (_tasks.ContainsKey(id))
            {
                _tasks.Remove(id);
                var result = _taskScheduler.RemoveTask(id.ToString());
                if (result)
                {
                    logAction($"[{DateTime.Now.ToString()}] Отслеживание мест остановлено");
                    return true;
                }
                else
                {
                    logAction($"[{DateTime.Now.ToString()}] Не удалось остановить отслеживание мест");
                    return false;
                }
            }
            logAction($"Задача с идентификатором {id.ToString()} не найдена");
            return false;
        }

        private void LogException(Exception ex)
        {
            Console.WriteLine($"[{DateTime.Now:dd-MM-yyyy HH:mm:ss}] Error happened.\nMessage - {ex.Message}\nStackTrace - {ex.StackTrace}");
        }
    }
}