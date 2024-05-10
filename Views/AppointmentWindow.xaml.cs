using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Bogus.Bson;
using Hospital_Appointment_Scheduling_System.Models;
using Hospital_Appointment_Scheduling_System.ViewModels;

namespace Hospital_Appointment_Scheduling_System.Views
{
    /// <summary>
    /// Interaction logic for AppointmentWindow.xaml
    /// </summary>
    public partial class AppointmentWindow : Window
    {
        public AppointmentWindow()
        {
            InitializeComponent();
            AppointmentViewModel viewModel = new AppointmentViewModel();
            this.DataContext = viewModel;

        }





        private void FilterTextBox_TextChanged(object sender, EventArgs e)
        {

            AppointmentList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            bool condition;
            var appointment = (Appointment)obj;
            if (FilterSearch.SelectedValue == "Patient")
            {
                condition = appointment.Patient.PatientName.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                condition = appointment.DoctorAssigned.Name.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
            }
            

            return condition;


        }


        private void FilterDate_ListChange(object sender, EventArgs e)
        {
            AppointmentList.Items.Filter = FilterDateMethod;
        }

        private bool FilterDateMethod(object obj)
        {

            var appointment = (Appointment)obj;

            string[] dateOnly = FilterDatePicked.ToString().Split(' ');//splitting the date and time

            return appointment.Date.ToString().Contains(dateOnly[0]);//index 0 is always the date



        }

     
    }
}
