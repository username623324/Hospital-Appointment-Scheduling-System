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
        public Patient? Patient { get; set; }
        public Doctor? DoctorAssigned { get; set; }
        public DateOnly? Date {  get; set; }
        public TimeOnly? Time { get; set; }
        public Status? Status { get; set; }
        private AvailableOrNot _condition;

        public AvailableOrNot Condition
        {
            get { return _condition; }
            set { _condition = value; OnPropertyChanged(nameof(Condition)); }
        }

        public Appointment(int? id, Patient? patient, Doctor? doctorAssigned, DateOnly? date, TimeOnly? time, Status? status)
        {
            Id = id;
            Patient = patient;
            DoctorAssigned = doctorAssigned;
            Date = date;
            Time = time;
            Status = status;
            Condition = AvailableOrNot.Available;
        }

        public Appointment()
        {

        }
    }
}
