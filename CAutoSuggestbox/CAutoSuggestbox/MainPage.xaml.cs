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

namespace CAutoSuggestbox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<string> Suggestions { get; private set; }
        public MainPage()
        {
            this.Suggestions = new ObservableCollection<string>();
            this.InitializeComponent();
            string Title = "binding text";
            this.DataContext = Title;
        }

        private async void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                Suggestions.Clear();
                Suggestions.Add(sender.Text + "1");
                Suggestions.Add(sender.Text + "2");
            }
            Control1.ItemsSource = Suggestions;
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await new Windows.UI.Popups.MessageDialog("test buttonclick").ShowAsync();
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private void Control1_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
        }

        private async void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
          if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
            System.Diagnostics.Debug.WriteLine("Btnshow.ispointover："+BtnShow.IsPointerOver);
        //  await new Windows.UI.Popups.MessageDialog("test buttonclick").ShowAsync();

        }

        private async void SuggestionsList2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //  await new Windows.UI.Popups.MessageDialog("selection changed").ShowAsync();
         if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        private void StackPanel_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
