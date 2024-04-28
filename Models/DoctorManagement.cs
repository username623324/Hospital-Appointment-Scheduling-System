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
            
            new Doctor(0, "sins", "eating ass", new List<Appointment>())

        };

        public static ObservableCollection<Doctor> GetDoctors()
        {
            Doctor emptydoctor = new Doctor();
            Patient emptypatient = new Patient();

            var faker = new Faker();
            faker.Random = new Randomizer(100);
            for (int i = 0; i < 10; i++)
            {
                
                string name = faker.Name.FullName();
                string specialization = faker.Random.Word();
                var fakes = new Doctor(i+1, name, specialization, new List<Appointment>());
                DoctorDataBase.Add(fakes);

                for (int j = 0; j < 5; j++)
                {
                    DateOnly date = faker.Date.BetweenDateOnly(new DateOnly(2024, 1, 1), new DateOnly(2025, 12, 31));
                    TimeOnly time = faker.Date.BetweenTimeOnly(new TimeOnly(8, 0), new TimeOnly(16, 0));
                    Appointment appointment = new Appointment(j + 1, date, time, emptypatient, DoctorDataBase[i+1]);
                    AppointmentManagement.AppointmentDataBase.Add(appointment);
                    DoctorDataBase[i+1].Appointments.Add(appointment);

                }



            }
            

            return DoctorDataBase;
        }
    }
}
