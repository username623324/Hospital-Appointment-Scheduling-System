﻿using Hospital_Appointment_Scheduling_System.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public enum Status
    {
        Upcoming, Ongoing, Completed, Cancelled, Free
    }

    public enum AvailableOrNot
    {
        Taken, Available
    }

    public class Appointment: NotifyPropertyChanged
    {
        public int? Id { get; set; }
        private Patient? _patient;
        private Doctor? _doctorAssigned;
        public DateOnly? Date {  get; set; }
        public TimeOnly? Time { get; set; }
        private Status? _status = Models.Status.Free;
        private AvailableOrNot _condition;



        public Patient? Patient
        {
            get { return _patient; }
            set
            {
                _patient = value;
                if(Patient.PatientName != null)
                {
                    Condition = AvailableOrNot.Taken;
                    
                    
                    if (DateOnly.FromDateTime(DateTime.Now) < Date)
                    {
                        Status = Models.Status.Upcoming;
                    }
                    else
                    {
                        Status = Models.Status.Completed;
                        Condition = AvailableOrNot.Available;
                    }
                        
                    
                }
                else
                    Condition = AvailableOrNot.Available;
                    
                    OnPropertyChanged("Patient");
            }
        }

        public Doctor? DoctorAssigned
        {
            get { return _doctorAssigned; }
            set
            {
                _doctorAssigned = value;
                OnPropertyChanged("DoctorAssigned");
            }
        }
        public Status? Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }
        public AvailableOrNot Condition
        {
            get { return _condition; }
            set { _condition = value; 
                OnPropertyChanged("Condition"); }
        }

        public Appointment(int? id, DateOnly? date, TimeOnly? time, Patient patient, Doctor doctorAssigned)
        {
            Id = id;
            Date = date;
            Time = time;
            Patient = patient;
            DoctorAssigned = doctorAssigned;
            
        }

        public Appointment()
        {

        }
    }
}
