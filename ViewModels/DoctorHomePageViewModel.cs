using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Appointment_Scheduling_System.Models;
using Hospital_Appointment_Scheduling_System.Commands;
using System.Collections.ObjectModel;
using Hospital_Appointment_Scheduling_System.Views;
using System.Windows.Input;
using System.Windows;

namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class DoctorHomePageViewModel: NotifyPropertyChanged
    {
        public Doctor LoggedInDoctor { get; set; }
        public ICommand LogOutCommand { get; set; }//logs out
        public ICommand ViewMyAppointmentCommand { get; set; }//views the doctor's appointment
        public ICommand ViewScheduledAppointmentCommand { get; set; }
        public ICommand ShowPatientsCommand { get; set; }//shows the list of patients

        public DoctorHomePageViewModel(Doctor loggedInDoctor)
        {
            ViewScheduledAppointmentCommand = new RelayCommand(ViewScheduledAppointment, (s)=> true);
            LoggedInDoctor = loggedInDoctor;
            LogOutCommand = new RelayCommand(LogOut, (s)=> true);
            ViewMyAppointmentCommand = new RelayCommand(ViewMyAppointment, (s)=>true);
            ShowPatientsCommand = new RelayCommand(ShowPatients, (s)=> true);

        }

        private void ShowPatients(object obj)
        {
            ShowPatientsWindow showPatientsWindow = new ShowPatientsWindow(LoggedInDoctor);
            showPatientsWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            showPatientsWindow.Show();
        }

        private void ViewScheduledAppointment(object obj)
        {
            AppointmentWindow apwindow = new AppointmentWindow();
            apwindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            apwindow.Show();
        }

        private void LogOut(object obj)
        {
            LogInWindow login = new LogInWindow();
            login.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            login.Show();
            var dochome = obj as Window;
            dochome.Close();
        }

        private void ViewMyAppointment(object obj)
        {
            DoctorsViewTheirAppointmentWindow doctorsViewTheirAppointmentWindow = new DoctorsViewTheirAppointmentWindow(LoggedInDoctor);
            doctorsViewTheirAppointmentWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            doctorsViewTheirAppointmentWindow.Show();
        }
    }
}
