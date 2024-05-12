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


        //code-behind that loops the video
        private void backgroundVideo_Loaded(object sender, RoutedEventArgs e)
        {
            backgroundVideo.Play();
        }

        private void backgroundVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            backgroundVideo.Position = TimeSpan.FromSeconds(0);
        }

    }
}
