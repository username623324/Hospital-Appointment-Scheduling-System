﻿using System;
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
    /// Interaction logic for AvailableAppointmentPWindow.xaml
    /// </summary>
    public partial class AvailableAppointmentPWindow : Window
    {
        public AvailableAppointmentPWindow(Patient patient, Doctor doctor)
        {
            InitializeComponent();
            AvailableAppointmentPViewModel availableAppointmentPVM = new AvailableAppointmentPViewModel(patient, doctor);
            this.DataContext = availableAppointmentPVM;

        }
    }
}
