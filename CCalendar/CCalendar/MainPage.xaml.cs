using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CCalendar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void CreateCalendarEntry_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = null;
            var appointment = new Windows.ApplicationModel.Appointments.Appointment();

            // StartTime
            var date = DateTime.Now;
            var timeZoneOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            var startTime = new DateTimeOffset(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, timeZoneOffset);
            appointment.StartTime = startTime;

            // Subject
            appointment.Subject = "Test Calendar Entry " + date.ToString();

            if (appointment.Subject.Length > 255)
            {
                errorMessage = "The subject cannot be greater than 255 characters.";
            }

            // Location
            appointment.Location = "Japan";

            if (appointment.Location.Length > 32768)
            {
                errorMessage = "The location cannot be greater than 32,768 characters.";
            }

            // Details
            appointment.Details = "Details";

            if (appointment.Details.Length > 1073741823)
            {
                errorMessage = "The details cannot be greater than 1,073,741,823 characters.";
            }

            // Duration
            // All Day
            appointment.AllDay = true;

            // Reminder            
            appointment.Reminder = TimeSpan.FromDays(1);

            //Busy Status            
            appointment.BusyStatus = Windows.ApplicationModel.Appointments.AppointmentBusyStatus.WorkingElsewhere;

            // Sensitivity            
            appointment.Sensitivity = Windows.ApplicationModel.Appointments.AppointmentSensitivity.Public;

            var rect = new Rect(new Point(Window.Current.Bounds.Width / 2, Window.Current.Bounds.Height / 2), new Size());
            String appointmentId = await Windows.ApplicationModel.Appointments.AppointmentManager.ShowAddAppointmentAsync(appointment, rect, Windows.UI.Popups.Placement.Default);


        }
    }
}
