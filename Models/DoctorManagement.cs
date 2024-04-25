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
            
            

        };

        public static ObservableCollection<Doctor> GetDoctors()
        {   
            List<Appointment> empty = new List<Appointment> ();
            Doctor doc = new Doctor();
            Patient patient = new Patient();
            Appointment lol = new Appointment(100, new DateOnly(2024,11,23),new TimeOnly(8,0), Status.Upcoming, patient, doc);
            empty.Add(lol);
            
            var faker = new Faker();
            faker.Random = new Randomizer(100);
            for (int i = 0; i < 10; i++)
            {
                string name = faker.Name.FullName();
                string specialization = faker.Random.Word();
                var fakes = new Doctor(i+1, name, specialization, empty);
                DoctorDataBase.Add(fakes);
 
            }
            return DoctorDataBase;
        }
    }
}
