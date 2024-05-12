using Hospital_Appointment_Scheduling_System.Models;
using Hospital_Appointment_Scheduling_System.ViewModels;
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

namespace Hospital_Appointment_Scheduling_System.Views
{
    /// <summary>
    /// Interaction logic for MakeAppointmentDWindow.xaml
    /// </summary>
    public partial class MakeAppointmentDWindow : Window
    {
        public MakeAppointmentDWindow(Doctor doctor)
        {
            InitializeComponent();
            MakeAppointmentViewModel makeAppointmentViewModel = new MakeAppointmentViewModel(doctor);
            this.DataContext = makeAppointmentViewModel;
        }


        private void FilterTextBoxAppointment_TextChanged(object sender, EventArgs e)
        {

            AppointmentList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
           
            var appointment = (Appointment)obj;
            return appointment.Id.ToString().Contains(FilterAppointmentTextBox.Text, StringComparison.OrdinalIgnoreCase);

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
