using System;
using System.Windows;
using EmiasClient.API.Models.Requests;
using EmiasClient.Application.Models;

namespace EmiasClient.Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowData _data;
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _data;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Test()
        {
            
        }
    }
}