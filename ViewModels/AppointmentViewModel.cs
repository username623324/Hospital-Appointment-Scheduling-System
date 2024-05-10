using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Appointment_Scheduling_System.Commands;
using Hospital_Appointment_Scheduling_System.Models;

namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class AppointmentViewModel: NotifyPropertyChanged
    {
        public ObservableCollection<Appointment> Appointments { get; set; }
        private List<string> _searchOptions = new List<string>() { "Doctor", "Patient"};
        private string _selectedOption = "Patient";

        public List<string> SearchOptions
        {
            get { return _searchOptions; }
            set { _searchOptions = value;
                OnPropertyChanged("SearchOptions");
            }
        }

        public string SelectedOption
        {
            get { return _selectedOption; }
            set { _selectedOption = value; OnPropertyChanged("SelectedOption"); }
        }

        public AppointmentViewModel()
        {
            
            Appointments = AppointmentManagement.GetScheduledAppointments();


        }
    }
}
