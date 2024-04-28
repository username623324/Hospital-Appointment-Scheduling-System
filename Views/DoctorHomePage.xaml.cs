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
    /// Interaction logic for DoctorHomePage.xaml
    /// </summary>
    public partial class DoctorHomePage : Window
    {
        public DoctorHomePage(Doctor doc)
        {
            InitializeComponent();
            DoctorHomePageViewModel doctorHomePageVM = new DoctorHomePageViewModel(doc);
            this.DataContext = doctorHomePageVM;
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
