using Hospital_Appointment_Scheduling_System.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public enum Status
    {
        Upcoming, Ongoing, Completed, Cancelled
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
        public Status? Status { get; set; }
        private AvailableOrNot _condition;


        public Patient? Patient
        {
            get { return _patient; }
            set
            {
                _patient = value;
                Condition = AvailableOrNot.Taken;
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

        public AvailableOrNot Condition
        {
            get { return _condition; }
            set { _condition = value; OnPropertyChanged(nameof(Condition)); }
        }

        public Appointment(int? id, DateOnly? date, TimeOnly? time, Status? status, Patient patient, Doctor doctorAssigned)
        {
            Id = id;
            Date = date;
            Time = time;
            Status = status;
            Patient = patient;
            DoctorAssigned = doctorAssigned;
            Condition = AvailableOrNot.Available;
        }

        public Appointment()
        {

        }
    }
}
