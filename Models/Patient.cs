﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Hospital_Appointment_Scheduling_System.Commands;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public class Patient: NotifyPropertyChanged
    {
       
        public int? Id { get; set; }
        private string? _patientName;
        private string? _patientContactNumber;
        private string? _patientMedicalHistory;

      
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

        public string? PatientMedicalHistory
        {
            get { return _patientMedicalHistory; }
            set { _patientMedicalHistory = value;
                OnPropertyChanged("PatientMedicalHistory");
            }
        }

        public Patient(int? id, string? patientName, string? patientContactNumber, string? patientMedicalHistory)
        {
            Id = id;
            PatientName = patientName;
            PatientContactNumber = patientContactNumber;
            PatientMedicalHistory = patientMedicalHistory;
        }

        public Patient() { }

    }
}
