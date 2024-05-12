﻿using Hospital_Appointment_Scheduling_System.Commands;
using Hospital_Appointment_Scheduling_System.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hospital_Appointment_Scheduling_System.Models;
using System.Windows.Controls;
using System.Windows;

namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class RegisterViewModel
    {
        public string? Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? MedicalHistory { get; set; }
        public ICommand AddCredentialsCommand {  get; set; }
        public ICommand CancelCommand { get; set; }
        public RegisterViewModel()
        {
            AddCredentialsCommand = new RelayCommand(AddCredentials, (s) => true);
            CancelCommand = new RelayCommand(Cancel, (s) => true);
        }

        private void Cancel(object obj)
        {
            LogInWindow logInWindow = new LogInWindow();
            logInWindow.WindowStartupLocation=WindowStartupLocation.CenterScreen;
            logInWindow.Show();


            var register = obj as Window;
            register.Close();
        }

        private void AddCredentials(object obj)
        {
            
            Patient patient = new Patient(PatientManagement.PatientDataBase.Count()+100, this.Name, this.ContactNumber, this.MedicalHistory);
            PatientManagement.AddPatient(patient);

            PatientHomePage patientHomePage = new PatientHomePage(patient);//after registering it will redirect it to patient home page
            patientHomePage.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            patientHomePage.Show();

            var register = obj as Window;
            register.Close();

            

        }
    }
}
