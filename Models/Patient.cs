using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public class Patient: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string? _patientId;
        private string? _patientName;
        private string? _patientContactNumber;
        private List<string>? _patientMedicalHistory;

        public string? PatientId 
        { 
            get { return _patientId; }
            set { _patientId = value; 
                OnPropertyChanged("PatientId"); } 
        }

        public string? PatientName
        {
            get { return _patientName; }
            set { _patientName = value;
                OnPropertyChanged("PatientName");
            }
        }

        public string? PatientContactNumber
        {
            get { return _patientContactNumber; }
            set { _patientContactNumber = value;
                OnPropertyChanged("PatientContactNumber");
            }
        }

        public List<string>? PatientMedicalHistory
        {
            get { return _patientMedicalHistory; }
            set { _patientMedicalHistory = value;
                OnPropertyChanged("PatientMedicalHistory");
            }
        }

        public Patient(string? patientId, string? patientName, string? patientContactNumber, List<string>? patientMedicalHistory)
        {
            PatientId = patientId;
            PatientName = patientName;
            PatientContactNumber = patientContactNumber;
            PatientMedicalHistory = patientMedicalHistory;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
