using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CListeView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListvewGap : Page
    {
        public ListvewGap()
        {
            this.InitializeComponent();
            ObservableCollection<ViewModel> my_keyframes = new ObservableCollection<ViewModel>
            {
                new ViewModel() {main_brush="Blue",washedout_brush="Red",transition_gradient="Aquamarine",display_transition_gradient="Visible",washout_transition_gradient="Yellow" },
                 new ViewModel() {main_brush="Blue",washedout_brush="Red",transition_gradient="Aquamarine",display_transition_gradient="Visible",washout_transition_gradient="Yellow" },
                   new ViewModel() {main_brush="Blue",washedout_brush="Red",transition_gradient="Aquamarine",display_transition_gradient="Visible",washout_transition_gradient="Yellow" }

            };
            List.ItemsSource = my_keyframes;
        }
    }
    public class ViewModel
    {
        public string main_brush { get; set; }
        public string washedout_brush { get; set; }
        public string transition_gradient { get; set; }
        public string display_transition_gradient { get; set; }
        public string washout_transition_gradient { get; set; }
    }
}
