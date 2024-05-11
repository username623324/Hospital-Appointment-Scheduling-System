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

        public static ObservableCollection<Appointment> ScheduledAppointmentDataBase { get; set; } = new ObservableCollection<Appointment>()
        {

        };
        public static ObservableCollection<Appointment> AssignedDoctorAppointments {  get; set; } = new ObservableCollection<Appointment>() {  };

        public static ObservableCollection<Appointment> GetAppointments()
        {   
            Doctor emptydoctor = new Doctor();
            Patient emptypatient = new Patient();
            var faker = new Faker();

            faker.Random = new Randomizer(123);

            for(int i = 0; i < 100;  i++)
            {
                
                DateOnly date = faker.Date.BetweenDateOnly(new DateOnly(2024, 5,11), new DateOnly(2024,5,31));
                TimeOnly time = faker.Date.BetweenTimeOnly(new TimeOnly(8,0), new TimeOnly(16,0));
                Appointment appointment = new Appointment(i+1, date, time, emptypatient, emptydoctor);
                AppointmentDataBase.Add(appointment);

            }

            return AppointmentDataBase; 
        }

        public static ObservableCollection<Appointment> GetScheduledAppointments()//finds all taken appointments in the database
        {

            foreach(Appointment appointment in AppointmentDataBase)
            {
                if(appointment.Condition == AvailableOrNot.Taken)
                {   if(!ScheduledAppointmentDataBase.Contains(appointment))
                    ScheduledAppointmentDataBase.Add(appointment);
                }
            }

            return ScheduledAppointmentDataBase;
            
        }

        public static void AssignAppointment()
        {
            int x = 0;
            GetAppointments();
            foreach(Doctor doctor in DoctorManagement.DoctorDataBase)//assigning 5 pre generated appointments to doctors
            {
                for(int i = 0; i < 5; i++)
                {
                    if (!doctor.Appointments.Contains(AppointmentDataBase[x]))
                    {
                        doctor.Appointments.Add(AppointmentDataBase[x]);
                        AppointmentDataBase[x].DoctorAssigned = doctor;
                    }
                    x++;
                }
                
            }

        }

        public static ObservableCollection<Appointment> GetPatientAppointments(Patient patient)
        {

           foreach(Appointment appointment in AppointmentDataBase)
           {
                if(appointment.Patient == patient)//finds all of the appointment's patient that equals to the logged in patient
                {
                    if(!PatientAppointmentDataBase.Contains(appointment))//if it is already on the database it wont add(so that it stops duplicating if the user closes and reopens the window)
                    PatientAppointmentDataBase.Add(appointment);
                }

           }

            return PatientAppointmentDataBase;

        }

        public static ObservableCollection<Appointment> GetAssignedDoctorAppointments()
        {
            foreach(Appointment appointment in AppointmentDataBase)//finds all appointments that has a doctor assigned to them
            {
                if(appointment.DoctorAssigned.Name != null)
                {
                    if(!AssignedDoctorAppointments.Contains(appointment))
                    AssignedDoctorAppointments.Add(appointment);

                }
            }

            return AssignedDoctorAppointments;
        }

        public static void AddAppointment(Appointment appointment, Patient patient)
        {
            if(appointment.Patient != patient)//checks if the appointment's patient is already assigned to the logged in patient
            {
                if (appointment.Condition != AvailableOrNot.Taken)//checks if it is taken
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
            else//returns when the appointment's patient is already the logged in patient
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
            if(appointment.Status != Status.Free)
            {
                if (appointment.Status != Status.Cancelled)
                {
                    appointment.Status = Status.Cancelled;//??not final
                    appointment.Condition = AvailableOrNot.Available;
                    appointment.Patient = new Patient();
                    PatientAppointmentDataBase.Remove(appointment);
                    string message = "Appointment cancelled";
                    string caption = "Information";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBox.Show(message, caption, button, icon);
                }
                else
                {
                    string message = "Appointment already cancelled!";
                    string caption = "Information";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBox.Show(message, caption, button, icon);
                }
            }
            else 
            {
                string message = "No appointment!";
                string caption = "Information";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(message, caption, button, icon);
            }
            
            
        }
    }
}
