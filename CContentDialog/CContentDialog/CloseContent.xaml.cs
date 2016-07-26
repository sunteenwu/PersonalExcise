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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CContentDialog
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CloseContent : Page
    {
        public CloseContent()
        {
            this.InitializeComponent();
        }
        private async void AddCookBook_Click(object sender, RoutedEventArgs e)
        {
            CookBookDialog newCookBookDialog = new CookBookDialog();
            newCookBookDialog.PrimaryButtonClick += NewCookBookDialog_PrimaryButtonClick;
            newCookBookDialog.Opened += NewCookBookDialog_Opened;
            newCookBookDialog.Closed += NewCookBookDialog_Closed;
            await newCookBookDialog.ShowAsync();
        }

        private void NewCookBookDialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
        {
            textBlock.Text = "Closed";
        }

        private void NewCookBookDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            textBlock.Text = "Open";
        }

        private void NewCookBookDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //p_App.DataBase.CookBooks.Add(((ContentDialog)sender).CookBook);
        }

        private async void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            CookBookDialog newRecipeDialog = new CookBookDialog();
            newRecipeDialog.PrimaryButtonClick += NewRecipeDialog_PrimaryButtonClick;
            await newRecipeDialog.ShowAsync();
        }

        private void NewRecipeDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
