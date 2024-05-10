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
using Hospital_Appointment_Scheduling_System.ViewModels;
using Hospital_Appointment_Scheduling_System.Models;

namespace Hospital_Appointment_Scheduling_System.Views
{
    /// <summary>
    /// Interaction logic for DoctorsViewTheirAppointmentWindow.xaml
    /// </summary>
    public partial class DoctorsViewTheirAppointmentWindow : Window
    {
        public DoctorsViewTheirAppointmentWindow(Doctor doctor)
        {
            InitializeComponent();
            DoctorsViewTheirAppointmentViewModel doctorsViewTheirAppointmentVM = new DoctorsViewTheirAppointmentViewModel(doctor);
            this.DataContext = doctorsViewTheirAppointmentVM;

        }
    }
}
