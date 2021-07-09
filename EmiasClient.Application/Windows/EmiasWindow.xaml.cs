using EmiasClient.Application.Models;
using EmiasClient.Scheduler.Models;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using EmiasClient.API;
using EmiasClient.API.Models.Requests;
using EmiasClient.API.Models.Requests.Params;
using EmiasClient.API.Models.Responses.Data;
using TaskScheduler = EmiasClient.Scheduler.TaskScheduler;

namespace EmiasClient.Application.Windows
{
    /// <summary>
    /// Логика взаимодействия для Emias.xaml
    /// </summary>
    public partial class EmiasWindow : Window
    {
        private WindowData _data;
        private TaskScheduler _taskScheduler;
        private Client _client;
        private bool _taskActive = false;
        private Guid _taskId;

        private Action<string> LogAction;
        
        public EmiasWindow()
        {
            InitializeComponent();
            _data = new WindowData();
            _data.Specialities = new ObservableCollection<SpecialityInfo>() { new SpecialityInfo() { Name = "asd" } };
            this.DataContext = _data;
            
            InitializeEmiasApi();
        }

        private void InitializeEmiasApi()
        {
            _client = new Client("https://emias.info/");
            _taskScheduler = new TaskScheduler();
            LogAction = (log) => _data.Logs += $"{log}\n";
            _data.ButtonText = "Запустить";
        }

        private void StartJob_click(object sender, RoutedEventArgs e)
        {
            if (_taskActive)
            {
                _taskScheduler.StopTask(_taskId, LogAction);
                _data.ButtonText = "Запустить";
                _taskActive = false;
            }
            else
            {
                _taskId = Guid.NewGuid();
                _taskScheduler.ScheduleTask
                (
                    new ScheduledTaskParameters()
                    {
                        Id = _taskId,
                        Name = "Test",
                        OmsNumber = "",
                        Birthday = new DateTime(1111,11,11),
                        SpecialityId = "112",
                        //LpuIds = new[] { 8299143654, 10000254 },
                        //DoctorIds = new[] { 10008173L },
                        MinTimeSpan = new TimeSpan(1, 0, 0),
                        //MaxTimeSpan = new TimeSpan(90, 0, 0),
                        MinAppointmentTime = new TimeSpan(11, 0, 0),
                        MaxAppointmentTime = new TimeSpan(22, 0, 0),
                        CreateRecord = false,
                        ToneNotification = true
                    }, LogAction
                );
                _data.ButtonText = "Остановить";
                _taskActive = true;
            }
        }

        private async void UpdateData_click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(_data.OmsNumber??"", @"\d{15}"))
            {
                LogAction("Неверный номер полиса");
                return;
            }
            var specialities = await _client.GetSpecialitiesInfoAsync(new GetSpecialitiesInfoRequest()
            {
                Param = new OmsData(_data.OmsNumber, _data.BirthDate)
            });
            _data.Specialities.Clear();
            foreach (var speciality in specialities.Result)
            {
                _data.Specialities.Add(speciality);
            }
        }
    }
}
