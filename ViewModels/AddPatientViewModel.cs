using Hospital_Appointment_Scheduling_System.Commands;
using Hospital_Appointment_Scheduling_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class AddPatientViewModel//unused
    {   
        public ICommand AddPatientCommand { get; set; }
        public string? Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? MedicalHistory { get; set; }

        public AddPatientViewModel()
        {
            AddPatientCommand = new RelayCommand(AddPatient, (s) => true);
        }

        private void AddPatient(object obj)
        {
            int id = PatientManagement.PatientDataBase.Count() +1;
            Patient newpatient = new Patient(id, this.Name, this.ContactNumber, this.MedicalHistory);
            PatientManagement.AddPatient(newpatient);
        }
    }
}
