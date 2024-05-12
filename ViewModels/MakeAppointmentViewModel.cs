using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hospital_Appointment_Scheduling_System.Commands;
using Hospital_Appointment_Scheduling_System.Models;

namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class MakeAppointmentViewModel: NotifyPropertyChanged
    {
        public ObservableCollection<Appointment> UnassignedAppointments { get; set; }
        private Appointment _selectedAppointment;
        private int _selectedAppointmentIndex;
        public Doctor LoggedInDoctor { get; set; }
        public ICommand AddAppointmentCommand {  get; set; }

        public Appointment SelectedAppointment
        {
            get {  return _selectedAppointment; }
            set { _selectedAppointment = value;
                OnPropertyChanged("SelectedApppointment");
            }
        }

        public int SelectedAppointmentIndex
        {
            get { return _selectedAppointmentIndex; }
            set { _selectedAppointmentIndex = value; OnPropertyChanged("SelectedAppointmentIndex"); }
        }

        public MakeAppointmentViewModel(Doctor doctor)
        {
            LoggedInDoctor = doctor;
            UnassignedAppointments = AppointmentManagement.GetUnassignedAppointments();
            AddAppointmentCommand = new RelayCommand(AddAppointment, (s) => true);
             
        }

        private void AddAppointment(object obj)
        {
            AppointmentManagement.AddUnassignedAppointment(LoggedInDoctor, SelectedAppointment);//adds an scheduled appointment slot for the doctor

        }
    }
}
