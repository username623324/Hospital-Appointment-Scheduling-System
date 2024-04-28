using Hospital_Appointment_Scheduling_System.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public class Doctor: NotifyPropertyChanged
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Specialization { get; set; }
        private List<Appointment>? _appointments; 

        public List<Appointment>? Appointments
        {
            get { return _appointments; }
            set { _appointments = value; OnPropertyChanged("Appointments"); }
        }

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
