using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital_Appointment_Scheduling_System.Models;
using Hospital_Appointment_Scheduling_System.Commands;
using System.Windows.Input;
using Hospital_Appointment_Scheduling_System.Views;
using System.Collections.ObjectModel;

namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class DoctorsViewTheirAppointmentViewModel: PatientViewTheirAppointmentViewModel
    {
        public Doctor LoggedInDoctor { get; set; }
        public ICommand RemoveAppointmentCommand { get; set; }
        public ICommand MakeAppointmentCommand { get; set; }
       

        public DoctorsViewTheirAppointmentViewModel(Doctor doctor): base(null)
        {
            LoggedInDoctor = doctor;
            RemoveAppointmentCommand = new RelayCommand(RemoveAppointment, (s) => true);
            MakeAppointmentCommand = new RelayCommand(MakeAppointment, (s)=> true);
        }

        private void MakeAppointment(object obj)
        {
            MakeAppointmentDWindow makeAppointmentDWindow = new MakeAppointmentDWindow(LoggedInDoctor);
            makeAppointmentDWindow.WindowStartupLocation=WindowStartupLocation.CenterScreen;
            makeAppointmentDWindow.Show();
        }

        private void RemoveAppointment(object obj)
        {
            AppointmentManagement.RemoveAppointment(SelectedAppointment, LoggedInDoctor);

        }
    }
}
