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
    public class PatientViewTheirAppointmentViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<Appointment> _appointments;
        public Patient Patient { get; set; }
        public ICommand CancelAppointmentCommand { get; set; }
        private Appointment _selectedAppointment;
        private int _selectedAppointmentIndex;
        private bool _buttonCommand;

        public bool ButtonCommand
        {
            get { return _buttonCommand; }
            set { _buttonCommand = value; 
                OnPropertyChanged("ButtonCommand"); }
        }

        public ObservableCollection<Appointment> Appointments
        {

            get { return _appointments; }
            set {_appointments = value; OnPropertyChanged("Appointments"); }
                

        }
        public Appointment SelectedAppointment
        {
            get { return _selectedAppointment; }
            set {
                _selectedAppointment = value; 
                if (value == null) 
                { 
                    ButtonCommand = false;//if the patients appointment is empty it wil disable the button to prevent an error in the code
                }
                else
                    ButtonCommand = true;
               OnPropertyChanged("SelectedAppointment"); } 
        
        }

        public int SelectedAppointmentIndex
        {
            get { return _selectedAppointmentIndex; }
            set { _selectedAppointmentIndex = value; 
                OnPropertyChanged("SelectedAppointmentIndex"); }
        }


        public PatientViewTheirAppointmentViewModel(Patient patient)
        {
            Appointments = AppointmentManagement.GetPatientAppointments(patient);//returns the appointments of patients
            Patient = patient;
            CancelAppointmentCommand = new RelayCommand(CancelAppointment, (s)=>true);
        }

        private void CancelAppointment(object obj)
        {

            AppointmentManagement.CancelAppointment(SelectedAppointment);//cancels the appointment

        }
    }
}
