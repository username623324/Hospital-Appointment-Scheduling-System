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
        public int? Id { get; set; }
        private string? _patientName;
        private string? _patientContactNumber;
        private List<string>? _patientMedicalHistory;

      
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

        public Patient(int? id, string? patientName, string? patientContactNumber, List<string>? patientMedicalHistory)
        {
            Id = id;
            PatientName = patientName;
            PatientContactNumber = patientContactNumber;
            PatientMedicalHistory = patientMedicalHistory;
        }

        public Patient() { }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
