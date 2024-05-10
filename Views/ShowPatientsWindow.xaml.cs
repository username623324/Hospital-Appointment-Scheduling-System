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
using Hospital_Appointment_Scheduling_System.Models;
using Hospital_Appointment_Scheduling_System.ViewModels;

namespace Hospital_Appointment_Scheduling_System.Views
{
    /// <summary>
    /// Interaction logic for ShowPatientsWindow.xaml
    /// </summary>
    public partial class ShowPatientsWindow : Window
    {
        public ShowPatientsWindow(Doctor doctor)
        {
            InitializeComponent();
            ShowPatientsViewModel showPatientsViewModel = new ShowPatientsViewModel(doctor);
            this.DataContext = showPatientsViewModel;
        }


        private void FilterTextBoxPatient_TextChanged(object sender, EventArgs e)
        {

            DoctorList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            bool condition;
            var user = (Patient)obj;
            if (FilterSearchPatient.SelectedValue == "Name")
            {
                condition = user.PatientName.Contains(FilterPatientTextBox.Text, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                string lol = Convert.ToString(user.Id);
                condition = lol.Contains(FilterPatientTextBox.Text, StringComparison.OrdinalIgnoreCase);
            }


            return condition;


        }


    }
}
