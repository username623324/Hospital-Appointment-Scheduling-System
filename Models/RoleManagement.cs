using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public class RoleManagement
    {
       
        public static ObservableCollection<Patient> PatientDataBase { get; set; } = new ObservableCollection<Patient>()
        {

            

        };


        public static ObservableCollection<Doctor> DoctorDataBase { get; set; } = new ObservableCollection<Doctor>()
        {

            

        };

        public static ObservableCollection<Patient> GetPatients()
        {
            List<string> medical = new List<string>();
            var faker = new Faker();
            faker.Random = new Randomizer(123);
            for (int i = 0; i < 100; i++)
            {
                string name = faker.Name.FullName();
                string id = faker.Company.CompanyName();
                string number = faker.Phone.PhoneNumber();
                for (int j = 0; j < 3; j++)
                {
                    string hurt = faker.Name.LastName();
                    medical.Add(hurt);
                }

                var fakes = new Patient(name, id, number, medical);
                PatientDataBase.Add(fakes);

            }
            return PatientDataBase;
        }

        public static ObservableCollection<Doctor> GetDoctors()
        {
            List<Appointment> list = new List<Appointment>();
            var faker = new Faker();
            faker.Random = new Randomizer(123);
            for(int i = 0;i < 10; i++)
            {
                string name = faker.Name.FullName();
                string id = faker.Random.Word();
                string specialization = faker.Random.Words();
                for(int j = 0; j < 1; j++)
                {
                    string fakeid = faker.Random.Word();
                    Appointment app = new Appointment(fakeid, )
                }
                var fakes = new Doctor(id, name, specialization, list);
                DoctorDataBase.Add(fakes);
            }
            return DoctorDataBase;
        }
    }
}
