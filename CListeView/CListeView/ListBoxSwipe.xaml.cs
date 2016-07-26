﻿using System;
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
    public sealed partial class ListBoxSwipe : Page
    {
        //ObservableCollection<string> ListTimeFrame;
        public ListBoxSwipe()
        {
            this.InitializeComponent();
            lblist.ItemsSource = GetData();
        }
        private ObservableCollection<string> GetData()
        {
            return new ObservableCollection<string>
            {
                "My Research Paper",
                "Electricity Bill",
                "My To-do list",
                "TV sales receipt",
                "Water Bill",
                "Grocery List",
                "Superbowl schedule",
                "World Cup E-ticket"
            };
        }

        private async void ActionGrid_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            await new Windows.UI.Popups.MessageDialog("started").ShowAsync();
        }

        private async void ActionGrid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            await new Windows.UI.Popups.MessageDialog("completed").ShowAsync();
        }
    }
}
