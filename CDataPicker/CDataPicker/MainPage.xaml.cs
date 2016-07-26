using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace CDataPicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Windows.Globalization.CalendarIdentifiers.Hijri;
            //System.Globalization.HijriCalendar
        }

        private void Btnsystem_Click(object sender, RoutedEventArgs e)
        {
            HijriCalendar myCal = new HijriCalendar();
            txtshow.Text = myCal.HijriAdjustment.ToString();

            // Creates a DateTime and initializes it to the second day of the first month of the year 1422.
            //DateTime myDT = new DateTime(1422, 1, 2, myCal);

            //// Displays the current values of the DateTime.
            //Console.WriteLine("HijriAdjustment is {0}.", myCal.HijriAdjustment);
            //Console.WriteLine("   Year is {0}.", myCal.GetYear(myDT));
            //Console.WriteLine("   Month is {0}.", myCal.GetMonth(myDT));
            //Console.WriteLine("   Day is {0}.", myCal.GetDayOfMonth(myDT));

            // Sets the HijriAdjustment property to 2.
            myCal.HijriAdjustment =1;
            txtshow.Text += myCal.HijriAdjustment.ToString();
            //viewControl.CalendarIdentifier = myCal;
            //SystemContain.Children.Add(myCal);
        }
    }
}
