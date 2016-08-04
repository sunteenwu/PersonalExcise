using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WPSLPhotoChoose.Resources;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;

namespace WPSLPhotoChoose
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly PhotoChooserTask photoTask = new PhotoChooserTask();
        string filepath = "";
        // Constructor
        public MainPage()
        {
            InitializeComponent();
          
            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;
            photoTask.ShowCamera = true;
      
            photoTask.Completed += photoTask_Completed;
            this.OrientationChanged += new EventHandler<OrientationChangedEventArgs>(Page_OrientationChanged);
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Page_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if ((e.Orientation & PageOrientation.Landscape) != 0)
            {
                //LandscapeColumn.Width = GridLength.Auto;
                //Grid.SetRow(imageBrowseBtn, 1);
                //Grid.SetColumn(imageBrowseBtn, 1);
                //LayoutRoot.ColumnDefinitions[1].Width = GridLength.Auto;
                ////Here margin left is set to 0
                //imageBrowseBtn.Margin = new Thickness(0);
            }

            else
            {
                //LandscapeColumn.Width = new GridLength(0);
                //Grid.SetRow(imageBrowseBtn, 2);
                //Grid.SetColumn(imageBrowseBtn, 0);
                //LayoutRoot.ColumnDefinitions[1].Width = new GridLength(0);
                ////Here margin left is set to 278
                //imageBrowseBtn.Margin = new Thickness(278, 0, 0, 0);
            }
        }

        void photoTask_Completed(object se, PhotoResult pr)
        {
            if (pr.Error != null || pr.TaskResult != TaskResult.OK)
                return;

          filepath = pr.OriginalFileName;

            Txtshow.Text = filepath;
          BitmapImage bmp = new BitmapImage();
            bmp.SetSource(pr.ChosenPhoto);
            imgshow.Source = bmp;
            //imgshow.Source = new BitmapImage(new Uri(pr.OriginalFileName));
        }

        private void phototask_Click(object sender, RoutedEventArgs e)
        {
            photoTask.Show();
        }

        private void Mediafind_Click(object sender, RoutedEventArgs e)
        { 
            PictureCollection picCollection;       
            MediaLibrary mediaLib = new MediaLibrary();
            picCollection = mediaLib.Pictures;
            int suff = filepath.LastIndexOf('.');
           string  filenamepart=filepath.Substring(suff - 5, 5);
            var picture = picCollection.FirstOrDefault(p => p.Name.Contains("filenamepart"));

            if (picture != null)
            {
                // Picture found
            }

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}

