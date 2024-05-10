using Hospital_Appointment_Scheduling_System.Commands;
using Hospital_Appointment_Scheduling_System.Models;
using Hospital_Appointment_Scheduling_System.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class PatientHomePageViewModel: NotifyPropertyChanged
    {  
        public Patient LoggedInPatient { get; set; }
        public ICommand ViewMyAppointmentCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand ShowDoctorCommand { get; set; }
     

        public PatientHomePageViewModel(Patient loggedInPatient)
        {
            ViewMyAppointmentCommand = new RelayCommand(ViewMyAppointment, (s)=> true);
            LogOutCommand = new RelayCommand(LogOut, (s)=> true);
            ShowDoctorCommand = new RelayCommand(ShowDoctor, (s)=> true);
            LoggedInPatient = loggedInPatient;
        }

        private void ShowDoctor(object obj)
        {
            ShowDoctorWindow showDoctorWindow = new ShowDoctorWindow(LoggedInPatient);
            showDoctorWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            showDoctorWindow.Show();
        }

        private void LogOut(object obj)
        {

            LogInWindow logInWindow = new LogInWindow();
            logInWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            logInWindow.Show();
            
            var window = obj as Window;
            window.Close();

            
        }

        private void ViewMyAppointment(object obj)
        {
            PatientViewTheirAppointmentWindow pvtaw = new PatientViewTheirAppointmentWindow(LoggedInPatient);
            pvtaw.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            pvtaw.Show();
        }
       


    }
}
