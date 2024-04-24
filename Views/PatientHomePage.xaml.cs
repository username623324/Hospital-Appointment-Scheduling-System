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
using Hospital_Appointment_Scheduling_System.Models;



namespace Hospital_Appointment_Scheduling_System.Views
{
    /// <summary>
    /// Interaction logic for PatientHomePage.xaml
    /// </summary>
    public partial class PatientHomePage : Window
    {
        public PatientHomePage()
        {
            InitializeComponent();
            PatientHomePageViewModel PatientHomePageVM = new PatientHomePageViewModel();
            this.DataContext = PatientHomePageVM;
            
        }

        private void FilterTextBoxDoctor_TextChanged(object sender, EventArgs e)
        {

            DoctorList.Items.Filter = FilterMethod;
        }

        private bool FilterMethod(object obj)
        {
            bool condition;
            var user = (Doctor)obj;
            if (FilterSearchDoctor.SelectedValue == "Name")
            {
                condition = user.Name.Contains(FilterDoctorTextBox.Text, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                condition = user.Specialization.Contains(FilterDoctorTextBox.Text, StringComparison.OrdinalIgnoreCase);
            }
                

            return condition;
            
            
        }

       
    }
}
