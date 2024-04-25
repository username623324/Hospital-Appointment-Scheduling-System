using Hospital_Appointment_Scheduling_System.Commands;
using Hospital_Appointment_Scheduling_System.Models;
using Hospital_Appointment_Scheduling_System.Views;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class LogInViewModel
    {   
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public string UserName { get; set; }
        public int Id { get; set; }
        public ICommand LogInCommand { get; set; }

        public LogInViewModel()
        {

            LogInCommand = new RelayCommand(LogIn, (s)=>true);

        }

        private void LogIn(object obj)
        {
            
            bool returned = false;
            bool IsAPatient = false;
            for(int i = 0; i<DoctorManagement.DoctorDataBase.Count; i++)
            {
                if(UserName == DoctorManagement.DoctorDataBase[i].Name && Id == DoctorManagement.DoctorDataBase[i].Id) 
                {

                    returned = true;
                }
                
            }
            for(int i = 0; i<PatientManagement.PatientDataBase.Count; i++)
            {
                if (UserName == PatientManagement.PatientDataBase[i].PatientName && Id == PatientManagement.PatientDataBase[i].Id)
                {
                    Patient = PatientManagement.PatientDataBase[i]; 
                    IsAPatient = true;
                    returned = true;
                    break;
                }
            }

            if(returned == true)
            {
                LogInWindow log = new LogInWindow();
                log.Hide();

                if (IsAPatient == true)
                {

                    PatientHomePage patientHomePage = new PatientHomePage(Patient);
                    patientHomePage.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    patientHomePage.Show();
                    
                }
                else
                {


                }

                
            }
            

        }
    }
}
