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
        public ICommand ViewMyAppointmentCommand { get; set; }//views the appointments of the patients
        public ICommand LogOutCommand { get; set; }//logout
        public ICommand ShowDoctorCommand { get; set; }//shows the doctor lists
        public ICommand ShowSearchAppointmentCommand { get; set; }//shows all the appointments with assigned doctors in the database
     

        public PatientHomePageViewModel(Patient loggedInPatient)
        {
            ShowSearchAppointmentCommand = new RelayCommand(ShowSearchAppointment, (s)=> true);
            ViewMyAppointmentCommand = new RelayCommand(ViewMyAppointment, (s)=> true);
            LogOutCommand = new RelayCommand(LogOut, (s)=> true);
            ShowDoctorCommand = new RelayCommand(ShowDoctor, (s)=> true);
            LoggedInPatient = loggedInPatient;
        }

        private void ShowSearchAppointment(object obj)
        {
            SearchAppointmentPWindow searchAppointmentPWindow = new SearchAppointmentPWindow(LoggedInPatient);
            searchAppointmentPWindow.WindowStartupLocation=WindowStartupLocation.CenterScreen;
            searchAppointmentPWindow.Show();
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
            AppointmentManagement.PatientAppointmentDataBase.Clear();//clears the patientappointmentdatabase so that if another user logs in they will only see their appointments
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
