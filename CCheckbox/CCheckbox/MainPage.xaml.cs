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

namespace CCheckbox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            OptionsAllCheckBox.IsChecked = null;
            var m = new MyViewModel();
            this.DataContext = m;
        }
        private void CheckBox_Loaded(object sender, RoutedEventArgs e)
        {
            var uiElement = sender as CheckBox;
            var binding = new Binding();
            binding.Path = new PropertyPath("NullCheck");
            uiElement.SetBinding(ToggleButton.IsCheckedProperty, binding);
        }

        private bool? nullCheck = null;

        public bool? NullCheck
        {
            get { return nullCheck; }
            set { nullCheck = value; }
        }
        private bool? isselectAll1 = null;
        public bool? IsSelectAll1
        {
            get
            {
                return isselectAll1;
            }
            set
            {
                isselectAll1 = value;
                OnPropertyChanged("IsSelectAll1");
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        private void SelectAll_Indeterminate(object sender, RoutedEventArgs e)
        {

        }
    }

    public class MyViewModel
    {
        private bool? isselectAll1 = null;
        public bool? IsSelectAll1
        {
            get
            {
                return isselectAll1;
            }
            set
            {
                isselectAll1 = value;
            }
        }
    }
}
