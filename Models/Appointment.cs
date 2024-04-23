using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public class Appointment
    {
        public string? Id { get; set; }
        public Patient? Patient { get; set; }
        public Doctor? DoctorAssigned { get; set; }
        public DateOnly? Date {  get; set; }
        public TimeOnly?Time { get; set; }
        public bool? Status { get; set; }

        public Appointment(string id, Patient patient, Doctor doctorAssigned, DateOnly date, TimeOnly time, bool status)
        {
            Id = id;
            Patient = patient;
            DoctorAssigned = doctorAssigned;
            Date = date;
            Time = time;
            Status = status;
        }

    }
}
