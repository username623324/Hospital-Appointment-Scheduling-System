using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital_Appointment_Scheduling_System.Models
{
    public class AppointmentManagement
    {
        public static ObservableCollection<Appointment> AppointmentDataBase { get; set; } = new ObservableCollection<Appointment>()
        {


        };

        public static ObservableCollection<Appointment> PatientAppointmentDataBase { get; set; } = new ObservableCollection<Appointment>()
        {


        };

        public static ObservableCollection<Appointment> GetAppointments()
        {   
            Doctor emptydoctor = new Doctor();
            Patient emptypatient = new Patient();
            var faker = new Faker();

            faker.Random = new Randomizer(123);

            for(int i = 0; i < 100;  i++)
            {
                
                DateOnly date = faker.Date.BetweenDateOnly(new DateOnly(2024, 1,1), new DateOnly(2025,12,31));
                TimeOnly time = faker.Date.BetweenTimeOnly(new TimeOnly(8,0), new TimeOnly(16,0));
                Appointment appointment = new Appointment(i+1, date, time, emptypatient, emptydoctor);
                AppointmentDataBase.Add(appointment);

            }

            return AppointmentDataBase; 
        }

        public static ObservableCollection<Appointment> GetPatientAppointments(Patient patient)
        {

           foreach(Appointment appointment in AppointmentDataBase)
           {
                if(appointment.Patient == patient)
                {
                    if(!PatientAppointmentDataBase.Contains(appointment))
                    PatientAppointmentDataBase.Add(appointment);
                }

           }

            return PatientAppointmentDataBase;

        }

        public static void AddAppointment(Appointment appointment, Patient patient)
        {
            if(appointment.Patient != patient)
            {
                if (appointment.Condition != AvailableOrNot.Taken)
                {
                    appointment.Patient = patient;
                    PatientAppointmentDataBase.Add(appointment);
                    string message = "Appointment Added!";
                    string caption = "Information";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBox.Show(message, caption, button, icon);
                }
                else
                {
                    string message = "Appointment already taken!";
                    string caption = "Information";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBox.Show(message, caption, button, icon);
                }
            }
            else
            {
                string message = "Appointment already added!";
                string caption = "Information";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(message, caption, button, icon);
            }

            
            


        }

        public static void CancelAppointment(Appointment appointment)
        {
            appointment.Patient = new Patient();
            
            PatientAppointmentDataBase.Remove(appointment);
        }
    }
}
