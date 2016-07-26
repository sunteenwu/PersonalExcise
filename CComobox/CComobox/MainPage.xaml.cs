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

namespace CComobox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //DbManager Manage = new DbManager();
            //Manage.Date = "testdata";
            //Manage.Reading = "aaa";

            //List<DbManager> managelist = new List<DbManager> { Manage };
            //BreakfastList.ItemsSource = managelist;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            // { };
            if (Item1.IsSelected == true)
            {
                //Manage = DataManager.GetRecord();
               BreakfastList.Visibility = Visibility.Visible;
               //var test= BreakfastList.Visibility;
            }
        }



    }
    class DbManager
    {
        public string Glucose { get; set;}
        public string Reading { get; set; }
        public string Reading1 { get; set; }
        public string Date { get; set; }
    }
}
