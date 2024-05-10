using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public class DoctorManagement
    {
        

        public static ObservableCollection<Doctor> DoctorDataBase { get; set; } = new ObservableCollection<Doctor>()
        {
            
            new Doctor(0,"sins", "ass", new List<Appointment>()),
            new Doctor(1, "Samantha", "Anesthesiology", new List<Appointment>()),
            new Doctor(2, "Jonathan", "Cardiology", new List<Appointment>()),
            new Doctor(3, "Roman", "Dermatology", new List<Appointment>()),
            new Doctor(4, "Dean", "Genetics and Genome", new List<Appointment>()),
            new Doctor(5, "Seth", "Neurology", new List<Appointment>()),
            new Doctor(6, "Brock", "Orthopaedic Surgery", new List<Appointment>()),
            new Doctor(7, "Chris", "Pathology", new List<Appointment>()),
            new Doctor(8, "Kevin", "Pediatrics", new List<Appointment>()),
            new Doctor(9, "Cassidy", "Plastic Surgery", new List<Appointment>()),
            new Doctor(10, "Jesse", "Psychiatry", new List<Appointment>())


        };

        public static ObservableCollection<Doctor> GetDoctors()
        {
            
            return DoctorDataBase;
            
        }


    }
}
