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
    public class SearchAppointmentViewModel: AvailableAppointmentPViewModel
    {
     
        public ObservableCollection<Appointment> Appointments { get; set; }
        private List<string> _searchOptions = new List<string>() { "Doctor", "ID" };
        private string _selectedOption = "Doctor";
       
        public List<string> SearchOptions
        {
            get { return _searchOptions; }
            set
            {
                _searchOptions = value;
                OnPropertyChanged("SearchOptions");
            }
        }

        public string SelectedOption
        {
            get { return _selectedOption; }
            set { _selectedOption = value; OnPropertyChanged("SelectedOption"); }
        }

        public SearchAppointmentViewModel(Patient patient): base(patient, null)
        {
            LoggedInPatient = patient;
            Appointments = AppointmentManagement.GetAssignedDoctorAppointments();//returns the appointment with assigned doctors
        }


 

    }
}
