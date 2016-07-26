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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CDataBinding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {      
        public ObservableCollection<Set> MagicSets { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            
            MagicSets = new ObservableCollection<Set>() {
                new Set("medium","U") {name="suntest1",gathererCode="code" },
                new Set ("medium","U"){ name="suntest2",gathererCode="code"}
            };
            //MagicSets = new ObservableCollection<Set>() {
            //    new Set("medium","Rarity1") {name="suntest1",gathererCode="code" },
            //    new Set ("medium","Rarity2"){ name="suntest2",gathererCode="code"}
            //};
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        { 
        }

        private void BtnGetimageuri_Click(object sender, RoutedEventArgs e)
        {
            new Windows.UI.Popups.MessageDialog(MagicSets[0].setImageUrl).ShowAsync();
        }
    }
}
