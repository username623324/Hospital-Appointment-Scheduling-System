using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Hospital_Appointment_Scheduling_System.Commands;
using Hospital_Appointment_Scheduling_System.Models;
using Hospital_Appointment_Scheduling_System.Views;
namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class EditPatientViewModel
    {   
        public ICommand SavePatientInfoCommand { get; set; }
        public Patient Patient { get; set; }
        public int? NewId {  get; set; }
        public string? NewPatientName { get; set; }
        public string? NewContactNumber { get; set; }

        public EditPatientViewModel(Patient patient)
        {
            Patient = patient;
            NewId = patient.Id;
            NewPatientName = patient.PatientName;
            NewContactNumber = patient.PatientContactNumber;
            SavePatientInfoCommand = new RelayCommand(SavePatientInfo, (s) => true);
        }

        private void SavePatientInfo(object obj)
        {
            Patient.PatientName = NewPatientName;
            Patient.PatientContactNumber = NewContactNumber;
            Patient.Id = NewId;

            var editPatientDWindow = obj as Window;
            editPatientDWindow.Close();

            string message = "Update Complete!";
            string caption = "Information";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(message, caption, button, icon);
        }
    }
}
