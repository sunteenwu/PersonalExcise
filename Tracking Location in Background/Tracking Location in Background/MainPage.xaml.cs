using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tracking_Location_in_Background
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {   
        // For background task registration
        private const string BackgroundTaskName = "SampleLocationBackgroundTask";
        private const string BackgroundTaskEntryPoint = "BackgroundTask.LocationBackgroundTask";
        private IBackgroundTaskRegistration _geolocTask = null; 
        public MainPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached. The Parameter
        /// property is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // Loop through all background tasks to see if SampleBackgroundTaskName is already registered
            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {
                if (cur.Value.Name == BackgroundTaskName)
                {
                    _geolocTask = cur.Value;
                    break;
                }
            }

            if (_geolocTask != null)
            {
                // Associate an event handler with the existing background task
                _geolocTask.Completed += OnCompleted;

                try
                {
                    BackgroundAccessStatus backgroundAccessStatus = BackgroundExecutionManager.GetAccessStatus();

                    switch (backgroundAccessStatus)
                    {
                        case BackgroundAccessStatus.Unspecified:
                        case BackgroundAccessStatus.Denied:
                            await new MessageDialog("Not able to run in background. Application must be added to the lock screen.").ShowAsync();
                            break;

                        default:
                            await new MessageDialog("Background task is already registered. Waiting for next update...").ShowAsync();                         
                            break;
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.ToString()).ShowAsync();
                  
                }
                UpdateButtonStates(/*registered:*/ true);
            }
            else
            {
                UpdateButtonStates(/*registered:*/ false);
            }
        }

        /// <summary>
        /// Invoked immediately before the Page is unloaded and is no longer the current source of a parent Frame.
        /// </summary>
        /// <param name="e">
        /// Event data that can be examined by overriding code. The event data is representative
        /// of the navigation that will unload the current Page unless canceled. The
        /// navigation can potentially be canceled by setting e.Cancel to true.
        /// </param>
        //protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        //{
        //    if (_geolocTask != null)
        //    {
        //        // Remove the event handler
        //        _geolocTask.Completed -= OnCompleted;
        //    }
        //    base.OnNavigatingFrom(e);
        //}

        /// <summary>
        /// This is the click handler for the 'Register' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async private void RegisterBackgroundTask(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get permission for a background task from the user. If the user has already answered once,
                // this does nothing and the user must manually update their preference via PC Settings.
                BackgroundAccessStatus backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();

                // Regardless of the answer, register the background task. If the user later adds this application
                // to the lock screen, the background task will be ready to run.
                // Create a new background task builder
                BackgroundTaskBuilder geolocTaskBuilder = new BackgroundTaskBuilder();

                geolocTaskBuilder.Name = BackgroundTaskName;
                geolocTaskBuilder.TaskEntryPoint = BackgroundTaskEntryPoint;

                // Create a new timer triggering at a 15 minute interval
                var trigger = new TimeTrigger(15, false);

                // Associate the timer trigger with the background task builder
                geolocTaskBuilder.SetTrigger(trigger);

                // Register the background task
                _geolocTask = geolocTaskBuilder.Register();

                // Associate an event handler with the new background task
                _geolocTask.Completed += OnCompleted;

                UpdateButtonStates(/*registered*/ true);

                switch (backgroundAccessStatus)
                {
                    case BackgroundAccessStatus.Unspecified:
                    case BackgroundAccessStatus.Denied:
                        await new MessageDialog("Not able to run in background. Application must be added to the lock screen.").ShowAsync();                    
                        break;

                    default:
                        // BckgroundTask is allowed                         
                        await new MessageDialog("Background task registered.").ShowAsync();
                        // Need to request access to location
                        // This must be done with the background task registeration
                        // because the background task cannot display UI.
                        RequestLocationAccess();
                        break;
                }
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.ToString()).ShowAsync();               
                UpdateButtonStates(/*registered:*/ false);
            }
        }

        /// <summary>
        /// Get permission for location from the user. If the user has already answered once,
        /// this does nothing and the user must manually update their preference via Settings.
        /// </summary>
        private async void RequestLocationAccess()
        {
            // Request permission to access location
            var accessStatus = await Geolocator.RequestAccessAsync();

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    break;

                case GeolocationAccessStatus.Denied:
                    await new MessageDialog("Access to location is denied.").ShowAsync();                
                    break;

                case GeolocationAccessStatus.Unspecified:
                    await new MessageDialog("Unspecificed error!").ShowAsync();                 
                    break;
            }
        }

        /// <summary>
        /// This is the click handler for the 'Unregister' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnregisterBackgroundTask(object sender, RoutedEventArgs e)
        {
            // Unregister the background task
            if (null != _geolocTask)
            {
                _geolocTask.Unregister(true);
                _geolocTask = null;
            }

            ScenarioOutput_Latitude.Text = "No data";
            ScenarioOutput_Longitude.Text = "No data";
            ScenarioOutput_Accuracy.Text = "No data";
            UpdateButtonStates(/*registered:*/ false);           
        }

        /// <summary>
        /// Event handle to be raised when the background task is completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnCompleted(IBackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs e)
        {
            if (sender != null)
            {
                // Update the UI with progress reported by the background task
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    try
                    {
                        // If the background task threw an exception, display the exception in
                        // the error text box.
                        e.CheckResult();

                        // Update the UI with the completion status of the background task
                        // The Run method of the background task sets this status. 
                        var settings = ApplicationData.Current.LocalSettings;
                        if (settings.Values["Status"] != null)
                        {
                            //_rootPage.NotifyUser(settings.Values["Status"].ToString(), NotifyType.StatusMessage);
                        }

                        // Extract and display location data set by the background task if not null
                        ScenarioOutput_Latitude.Text = (settings.Values["Latitude"] == null) ? "No data" : settings.Values["Latitude"].ToString();
                        ScenarioOutput_Longitude.Text = (settings.Values["Longitude"] == null) ? "No data" : settings.Values["Longitude"].ToString();
                        ScenarioOutput_Accuracy.Text = (settings.Values["Accuracy"] == null) ? "No data" : settings.Values["Accuracy"].ToString();
                    }
                    catch (Exception ex)
                    {
                        // The background task had an error
                        await new MessageDialog(ex.ToString()).ShowAsync();
                    }
                });
            }
        }

        /// <summary>
        /// Update the enable state of the register/unregister buttons.
        /// 
        private async void UpdateButtonStates(bool registered)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    RegisterBackgroundTaskButton.IsEnabled = !registered;
                    UnregisterBackgroundTaskButton.IsEnabled = registered;
                });
        }

    }
}
