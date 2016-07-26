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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CButton
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ChangeBackground.Background = new SolidColorBrush(Windows.UI.Colors.Red);
        }

        private void ChangeBackground_Click(object sender, RoutedEventArgs e)
        {
            Button BtnAddToRela = new Button();
            BtnAddToRela.Content = "test add to relative";
            BtnAddToRela.Background= new SolidColorBrush(Windows.UI.Colors.Pink);
            RePanel.Children.Add(BtnAddToRela);
            
        }

        private void CustomHyperlink_Click(object sender, RoutedEventArgs e)
        {
            //string linkText = "test hyperlink";
            //Hyperlink lnk = new Hyperlink();
            //lnk.Inlines.Add(new Run { Text = linkText });
            //// RePanel.Children.Add(lnk);
            ////lnk.Foreground = Application.Current.Resources["pr0_orange"] as SolidColorBrush;
            //lnk.Foreground = new SolidColorBrush(Windows.UI.Colors.Blue);

            // Create a TextBlock. The hyperlink is the TextBlock content. 
            TextBlock tb = new TextBlock();

            // Create a Hyperlink and a Run. 
            // The Run provides the visible content of the hyperlink. 
            Hyperlink hyperlink = new Hyperlink();
            Run run = new Run();

            // Set the Text property on the Run. This will be the visible text of the hyperlink.
            run.Text = "Go to Bing";
            // Set the URI for the Hyperlink. 
            hyperlink.NavigateUri = new Uri("http://www.bing.com");

            // Add the Run to Hyperlink.Inlines collection.
            hyperlink.Inlines.Add(run);
            // Add the text elements to the TextBlock.Inlines collection.
            tb.Inlines.Add(hyperlink);
            // Add the TextBlock to a StackPanel (defined in the XAML page).        
            RePanel.Children.Add(tb);
        }
    }
}
