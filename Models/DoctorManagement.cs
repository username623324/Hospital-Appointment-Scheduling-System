using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            List<Appointment> list = new List<Appointment>();
            var faker = new Faker();
            faker.Random = new Randomizer(100);
            for (int i = 0; i < 10; i++)
            {
                string name = faker.Name.FullName();
                string specialization = faker.Random.Word();
                var fakes = new Doctor(i+1, name, specialization, list);
                DoctorDataBase.Add(fakes);
            }
            return DoctorDataBase;
        }
    }
}
