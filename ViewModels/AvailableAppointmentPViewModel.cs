using Hospital_Appointment_Scheduling_System.Commands;
using Hospital_Appointment_Scheduling_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class AvailableAppointmentPViewModel: NotifyPropertyChanged
    {
        public Patient LoggedInPatient { get; set; }
        public Doctor Doctor { get; set; }
        public ICommand AddAppointmentCommand { get; set; }

        private Appointment _selectedAppontment;
        private int _selectedAppointmentIndex;

        public int SelectedAppointmentIndex
        {
            get { return _selectedAppointmentIndex; } 
            set { _selectedAppointmentIndex = value; OnPropertyChanged("SelectedAppointmentIndex"); }
        }

        public Appointment SelectedAppointment
        {
            get { return _selectedAppontment; }
            set { _selectedAppontment = value; OnPropertyChanged("SelectedAppointment"); } 
        }


        public AvailableAppointmentPViewModel(Patient patient, Doctor doctor)
        {
            Doctor = doctor;
            LoggedInPatient = patient;
            AddAppointmentCommand = new RelayCommand(AddAppointment, (s) => true);
        }

        private void AddAppointment(object obj)
        {
                  
            AppointmentManagement.AddAppointment(SelectedAppointment, LoggedInPatient);

        }
    }
}
