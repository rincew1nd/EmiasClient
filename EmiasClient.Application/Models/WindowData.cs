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
            get
            {
                return _logs;
            }
            set
            {
                _logs = value;
                OnNotifyPropertyChanged("Logs");
            }
        }

        private string _buttonText;
        public string ButtonText
        {
            get
            {
                return _buttonText;
            }
            set
            {
                _buttonText = value;
                OnNotifyPropertyChanged("ButtonText");
            }
        }
        
        private string _omsNumber;
        public string OmsNumber
        {
            get
            {
                return _omsNumber;
            }
            set
            {
                _omsNumber = value;
                OnNotifyPropertyChanged("OmsNumber");
            }
        }
        
        private DateTime _birthdate;
        public DateTime BirthDate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
                OnNotifyPropertyChanged("BirthDate");
            }
        }
        
        private string _selectedSpeciality;
        public string SelectedSpeciality
        {
            get
            {
                return _selectedSpeciality;
            }
            set
            {
                _selectedSpeciality = value;
                OnNotifyPropertyChanged("SelectedSpeciality");
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