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

namespace UWP_App_Randomly_Crashes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DateTime starttime = new DateTime(2016, 5, 31);
            today today = new today() { StartTime = DateTime.Now,Day=starttime };
            this.DataContext = today;
        }
    }
    public class today
    {
        public DateTime Day { get; set; }
        public DateTime StartTime { get; set; }
    }

    public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value is DateTime)
                {
                    DateTime date = (DateTime)value;
                    return new DateTimeOffset(date);
                }
                else
                    return new DateTimeOffset(DateTime.Now);
            }
            catch (Exception ex)
            {
                return new DateTimeOffset(DateTime.Now);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset dto = (DateTimeOffset)value;
            return dto.DateTime;
        }
    }
    public class DateTimeToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value is DateTime)
                {
                    DateTime date = (DateTime)value;
                    return new TimeSpan(date.Ticks);
                }
                else
                    return new TimeSpan(DateTime.Now.Ticks);
            }
            catch (Exception ex)
            {
                return new TimeSpan(DateTime.Now.Ticks);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            TimeSpan ts = (TimeSpan)value;
            DateTime dt = new DateTime(ts.Ticks);

            return dt;
        }
    }
}
