using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.Phone.Media.Devices;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FullSize
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SystemMediaTransportControls systemMediaControls = null;
        public MainPage()
        {
            this.InitializeComponent();
            //mediaElement.MediaEnded += MediaElement_MediaEnded;
            systemMediaControls = SystemMediaTransportControls.GetForCurrentView();
            systemMediaControls.IsEnabled = true;
            systemMediaControls.IsNextEnabled = true;
            systemMediaControls.IsNextEnabled = true;
            systemMediaControls.ButtonPressed += systemMediaControls_ButtonPressed;
        }

        //private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    if (mediaElement.IsFullWindow == true)
        //    {
        //        mediaElement.IsFullWindow = false;
        //    }
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    mediaElement.IsFullWindow = !mediaElement.IsFullWindow;
        //}
        private void SetupSystemMediaTransportControls()
        {

            // To receive notifications for the user pressing media keys (eg. "Stop") on the keyboard, or 
            // clicking/tapping on the equivalent software buttons in the system media transport controls UI, 
            // all of the following needs to be true:
            //     1. Register for ButtonPressed event on the SystemMediaTransportControls object.
            //     2. IsEnabled property must be true to enable SystemMediaTransportControls itself.
            //        [Note: IsEnabled is initialized to true when the system instantiates the
            //         SystemMediaTransportControls object for the current app view.]
            //     3. For each button you want notifications from, set the corresponding property to true to
            //        enable the button.  For example, set IsPlayEnabled to true to enable the "Play" button 
            //        and media key.
            //        [Note: the individual button-enabled properties are initialized to false when the
            //         system instantiates the SystemMediaTransportControls object for the current app view.]
            //
            // Here we'll perform 1, and 3 for the buttons that will always be enabled for this scenario (Play,
            // Pause, Stop).  For 2, we purposely set IsEnabled to false to be consistent with the scenario's 
            // initial state of no media loaded.  Later in the code where we handle the loading of media
            // selected by the user, we will enable SystemMediaTransportControls.
            systemMediaControls.ButtonPressed += systemMediaControls_ButtonPressed;
        }

        private async void systemMediaControls_ButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                switch (args.Button)
                {
                    case SystemMediaTransportControlsButton.Pause:
                        Debug.WriteLine("Button pressed: ");
                        break;
                }
            });
        }

        private async void SelectFilesButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.ViewMode = PickerViewMode.List;
            filePicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            filePicker.CommitButtonText = "Play";
       

            IReadOnlyList<StorageFile> selectedFiles = await filePicker.PickMultipleFilesAsync();

        }

        private void Detectheadset_Click(object sender, RoutedEventArgs e)
        {

            AudioRoutingManager manager = AudioRoutingManager.GetDefault();
            manager.AudioEndpointChanged += Manager_AudioEndpointChanged; 
          // var discovery= AudioRoutingEndpoint.Default;
            //TxtResult.Text = discovery.ToString();

        }

        private void Manager_AudioEndpointChanged(AudioRoutingManager sender, object args)
        {

            //var discovery = AudioRoutingEndpoint.Default;
            //TxtResult.Text = discovery.ToString();
            
        }

      


        //void SystemControls_ButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
        //{
        //    switch (args.Button)
        //    {
        //        case SystemMediaTransportControlsButton.Play:
        //            PlayMedia();
        //            break;
        //        case SystemMediaTransportControlsButton.Pause:
        //            PauseMedia();
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //async void PlayMedia()
        //{
        //    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        //    {
        //        mediaElement.Play();
        //    });
        //}

        //async void PauseMedia()
        //{
        //    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        //    {
        //        mediaElement.Pause();
        //    });
        //}

    }
}
