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
        public ObservableCollection<Doctor> Doctors { get; set; }
        private List<string> _searchOptions = new List<string>() { "Name", "Specialization"};
        private string _selectedOption = "Name";
        private Doctor _selectedDoctor;
        private int _selectedDoctorIndex;
        public ICommand ViewAppointmentCommand { get; set; }

        public List<string> SearchOptions
        {
            get { return _searchOptions; }
            set { _searchOptions = value; OnPropertyChanged("SearchOptions"); }
        }

        public string SelectedOption
        {
            get { return _selectedOption; }
            set { _selectedOption = value; OnPropertyChanged("SelectedOption"); }
        }

        public Doctor SelectedDoctor
        {
            get { return _selectedDoctor; }
            set
            {
                _selectedDoctor = value;
                OnPropertyChanged("SelectedDoctor");
            }
        }

        public int SelectedDoctorIndex
        {
            get { return _selectedDoctorIndex; }
            set { _selectedDoctorIndex = value;
                OnPropertyChanged("SelectedDoctorIndex");
            }
        }


        public PatientHomePageViewModel(Patient loggedInPatient)
        {
            Doctors = DoctorManagement.GetDoctors();
            ViewAppointmentCommand = new RelayCommand(ViewAppointment, (s) => true);
            LoggedInPatient = loggedInPatient;

        }

        private void ViewAppointment(object obj)
        {
            var availableAppointmentPVM = new AvailableAppointmentPViewModel(SelectedDoctor);
            var availableAppointmentPWindow = new AvailableAppointmentPWindow();

            availableAppointmentPWindow.DataContext = availableAppointmentPVM;
            availableAppointmentPWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            availableAppointmentPWindow.Show();
        }
    }
}
