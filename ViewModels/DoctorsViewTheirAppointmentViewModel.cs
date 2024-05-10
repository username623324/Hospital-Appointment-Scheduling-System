using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Appointment_Scheduling_System.Models;

namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class DoctorsViewTheirAppointmentViewModel
    {
        public Doctor Doctor { get; set; }
        public List<Appointment> Appointments { get; set; }


        public DoctorsViewTheirAppointmentViewModel(Doctor doctor)
        {
            Doctor = doctor;
            Appointments = doctor.Appointments;
        }




    }
}
