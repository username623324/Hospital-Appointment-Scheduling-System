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
    public class Appointment
    {
        public int? Id { get; set; }
        public Patient? Patient { get; set; }
        public Doctor? DoctorAssigned { get; set; }
        public DateOnly? Date {  get; set; }
        public TimeOnly?Time { get; set; }
        public Status? Status { get; set; }

        public Appointment(int? id, Patient? patient, Doctor? doctorAssigned, DateOnly? date, TimeOnly? time, Status? status)
        {
            Id = id;
            Patient = patient;
            DoctorAssigned = doctorAssigned;
            Date = date;
            Time = time;
            Status = status;
        }

        public Appointment()
        {

        }
    }
}
