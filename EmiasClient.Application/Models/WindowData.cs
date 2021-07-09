using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using EmiasClient.API.Models.Responses.Data;

namespace EmiasClient.Application.Models
{
    public class WindowData: INotifyPropertyChanged
    {
        public ObservableCollection<SpecialityInfo> Specialities { get; set; }

        private string _logs;
        public string Logs
        {
            get => _logs;
            set
            {
                _logs = value;
                OnNotifyPropertyChanged("Logs");
            }
        }

        private string _buttonText;
        public string ButtonText
        {
            get => _buttonText;
            set
            {
                _buttonText = value;
                OnNotifyPropertyChanged("ButtonText");
            }
        }
        
        private string _omsNumber;
        public string OmsNumber
        {
            get => _omsNumber;
            set
            {
                _omsNumber = value;
                OnNotifyPropertyChanged("OmsNumber");
            }
        }
        
        private DateTime _birthdate;
        public DateTime BirthDate
        {
            get => _birthdate;
            set
            {
                _birthdate = value;
                OnNotifyPropertyChanged("BirthDate");
            }
        }
        
        private string _selectedSpeciality;
        public string SelectedSpeciality
        {
            get => _selectedSpeciality;
            set
            {
                _selectedSpeciality = value;
                OnNotifyPropertyChanged("SelectedSpeciality");
            }
        }
        
        private DateTime _minAppointmentTime;
        public DateTime MinAppointmentTime
        {
            get => _minAppointmentTime;
            set
            {
                _minAppointmentTime = value;
                OnNotifyPropertyChanged("MinAppointmentTime");
            }
        }
        
        private DateTime _maxAppointmentTime;
        public DateTime MaxAppointmentTime
        {
            get => _maxAppointmentTime;
            set
            {
                _maxAppointmentTime = value;
                OnNotifyPropertyChanged("MaxAppointmentTime");
            }
        }
        
        private DateTime _minTimeSpan;
        public DateTime MinTimeSpan
        {
            get => _minTimeSpan;
            set
            {
                _minTimeSpan = value;
                OnNotifyPropertyChanged("MinTimeSpan");
            }
        }
        
        private DateTime _maxTimeSpan;
        public DateTime MaxTimeSpan
        {
            get => _maxTimeSpan;
            set
            {
                _maxTimeSpan = value;
                OnNotifyPropertyChanged("MaxTimeSpan");
            }
        }
        
        private bool _createRecord;
        public bool CreateRecord
        {
            get => _createRecord;
            set
            {
                _createRecord = value;
                OnNotifyPropertyChanged("CreateRecord");
            }
        }
        
        private bool _toneNotification;
        public bool ToneNotification
        {
            get => _toneNotification;
            set
            {
                _toneNotification = value;
                OnNotifyPropertyChanged("ToneNotification");
            }
        }

        private void OnNotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}