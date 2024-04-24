using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public class Doctor
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Specialization { get; set; }
        public List<Appointment>? Appointments { get; set; }

        public Doctor(int? id, string? name, string? specialization, List<Appointment>? appointments)
        {
            Id = id;
            Name = name;
            Specialization = specialization;
            Appointments = appointments;
        }

        public Doctor() 
        { 

        }
    }
}
