using Hospital_Appointment_Scheduling_System.Commands;
using Hospital_Appointment_Scheduling_System.Models;
using Hospital_Appointment_Scheduling_System.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class ShowPatientsViewModel: NotifyPropertyChanged
    {
        public ObservableCollection<Patient> Patients { get; set; }
        public Doctor LoggedInDoctor { get; set; }
        private Patient _selectedPatient;
        private int _selectedPatientIndex;
        private List<string> _searchOptions = new List<string>() { "Name", "ID" };//combobox item
        private string _selectedOption = "Name";
        public ICommand EditPatientInfoCommand { get; set; }
       

        public List<string> SearchOptions
        {
            get { return _searchOptions; }
            set { _searchOptions = value; OnPropertyChanged(nameof(SearchOptions)); }
        }

        public string SelectedOption
        {
            get { return _selectedOption; }
            set { _selectedOption = value; OnPropertyChanged(nameof(SelectedOption)); }
        }

        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        public int SelectedPatientIndex
        {
            get { return _selectedPatientIndex; }
            set
            {
                _selectedPatientIndex = value;
                OnPropertyChanged(nameof(SelectedPatientIndex));
            }
        }

        public ShowPatientsViewModel(Doctor loggedInDoctor)
        {

            Patients = PatientManagement.GetPatients();
            LoggedInDoctor = loggedInDoctor;
            EditPatientInfoCommand = new RelayCommand(EditPatientInfo, (s) => true);

        }

        private void EditPatientInfo(object obj)
        {
            EditPatientDWindow editPatientDWindow = new EditPatientDWindow(SelectedPatient);
            editPatientDWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editPatientDWindow.Show();
        }



    }
}
