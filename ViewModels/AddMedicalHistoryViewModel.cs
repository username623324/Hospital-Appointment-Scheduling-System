using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Hospital_Appointment_Scheduling_System.Commands;
using Hospital_Appointment_Scheduling_System.Models;
namespace Hospital_Appointment_Scheduling_System.ViewModels
{
    public class AddMedicalHistoryViewModel
    {
        
        public Patient Patient { get; set; }
        public string? MedicalInfo { get; set; }
        public ICommand AddMedicalInfoCommand { get; set; }
        public List<string> TempMedicalHistory { get; set; }
       
        

        public AddMedicalHistoryViewModel(List<string> temp)
        {
            
            AddMedicalInfoCommand = new RelayCommand(AddMedicalInfo, (s)=> true);
            TempMedicalHistory = temp;
        }

        private void AddMedicalInfo(object obj)
        {
            TempMedicalHistory.Add(MedicalInfo);
            var window = obj as Window;
            window.Close();

        }
    }
}
