using Bogus;
using Hospital_Appointment_Scheduling_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public class PatientManagement
    {

        public static ObservableCollection<Patient> PatientDataBase { get; set; } = new ObservableCollection<Patient>()
        {

            new Patient(0,"joe","123", new List<string>())

        };

        public static ObservableCollection<Patient> GetPatients()
        {
            List<string> medical = new List<string>();
            var faker = new Faker();
            faker.Random = new Randomizer(123);
            for (int i = 0; i < 100; i++)
            {
                string name = faker.Name.FullName();
                string number = faker.Phone.PhoneNumber();

                var fakes = new Patient(i+1, name, number, medical);
                PatientDataBase.Add(fakes);

            }
            return PatientDataBase;
        }

        public static void AddPatient(Patient patient)
        {
            PatientDataBase.Add(patient);
        }


    }
}
