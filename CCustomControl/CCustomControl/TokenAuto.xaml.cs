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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CCustomControl
{
    public sealed partial class TokenAuto : UserControl
    {
        public ObservableCollection<string> Suggestions { get; private set; }
        public TokenAuto()
        {
            this.Suggestions = new ObservableCollection<string>();
            this.InitializeComponent();
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                Suggestions.Clear();
                Suggestions.Add(sender.Text + "1");
                Suggestions.Add(sender.Text + "2");
            }
            Control1.ItemsSource = Suggestions;
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            SuggestionOutput.Text = args.SelectedItem.ToString();
            Button btnOut = new Button();
            btnOut.Content= args.SelectedItem.ToString();
            wrapper.Children.Add(btnOut);
        }
    }
}
