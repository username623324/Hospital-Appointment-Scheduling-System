using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public class AppointmentManagement
    {
        public static ObservableCollection<Appointment> AppointmentDataBase { get; set; } = new ObservableCollection<Appointment>()
        {


        };


        public static ObservableCollection<Appointment> GetAppointments()
        {   
            Doctor emptydoctor = new Doctor();
            Patient emptypatient = new Patient();
            Status status = new Status();

            var faker = new Faker();

            faker.Random = new Randomizer(123);

            for(int i = 0; i < 100;  i++)
            {
                
                DateOnly date = faker.Date.BetweenDateOnly(new DateOnly(2024, 1,1), new DateOnly(2025,12,31));
                TimeOnly time = faker.Date.BetweenTimeOnly(new TimeOnly(8,0), new TimeOnly(16,0));
                Appointment appointment = new Appointment(i+1, emptypatient, emptydoctor, date, time, status);
                AppointmentDataBase.Add(appointment);
            }
            return AppointmentDataBase; 
        }
    }
}
