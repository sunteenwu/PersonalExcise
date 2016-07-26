using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CMultipleViews
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        //I use this boolean to determine if the application has already been launched once
        private bool alreadyLaunched = false;

        public ObservableCollection<ViewLifetimeControl> SecondaryViews = new ObservableCollection<ViewLifetimeControl>();
        private CoreDispatcher mainDispatcher;
        public CoreDispatcher MainDispatcher
        {
            get
            {
                return mainDispatcher;
            }
        }

        private int mainViewId;
        public int MainViewId
        {
            get
            {
                return mainViewId;
            }
        }

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                alreadyLaunched = true;
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            else if (alreadyLaunched)
            {
                var selectedView = await createMainPageAsync();
                if (null != selectedView)
                {
                    selectedView.StartViewInUse();
                    var viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                        selectedView.Id,
                        ViewSizePreference.Default,
                        ApplicationView.GetForCurrentView().Id,
                        ViewSizePreference.Default
                        );

                    await selectedView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        var currentPage = (MainPage)((Frame)Window.Current.Content).Content;
                        Window.Current.Activate();
                    });

                    selectedView.StopViewInUse();
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        protected override async void OnFileActivated(FileActivatedEventArgs args)
        {
            base.OnFileActivated(args);

            if (alreadyLaunched)
            {
                //Frame rootFrame = Window.Current.Content as Frame;
                //((MainPage)rootFrame.Content).OpenFileActivated(args);
                var selectedView = await createMainPageAsync();
                if (null != selectedView)
                {
                    selectedView.StartViewInUse();
                    var viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                        selectedView.Id,
                        ViewSizePreference.Default,
                        ApplicationView.GetForCurrentView().Id,
                        ViewSizePreference.Default
                        );

                    await selectedView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        var currentPage = (MainPage)((Frame)Window.Current.Content).Content;
                        Window.Current.Activate();
                        currentPage.OpenFileActivated(args);
                    });

                    selectedView.StopViewInUse();
                }
            }
            else
            {
                Frame rootFrame = new Frame();
                rootFrame.Navigate(typeof(MainPage), args);
                Window.Current.Content = rootFrame;
                Window.Current.Activate();
                alreadyLaunched = true;
            }
        }

        partial void Construct();
        partial void OverrideOnLaunched(LaunchActivatedEventArgs args, ref bool handled);
        partial void InitializeRootFrame(Frame frame);

        partial void OverrideOnLaunched(LaunchActivatedEventArgs args, ref bool handled)
        {
            // Check if a secondary view is supposed to be shown
            ViewLifetimeControl ViewLifetimeControl;
            handled = TryFindViewLifetimeControlForViewId(args.CurrentlyShownApplicationViewId, out ViewLifetimeControl);
            if (handled)
            {
                var task = ViewLifetimeControl.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Window.Current.Activate();
                });
            }
        }

        partial void InitializeRootFrame(Frame frame)
        {
            mainDispatcher = Window.Current.Dispatcher;
            mainViewId = ApplicationView.GetForCurrentView().Id;
        }

        bool TryFindViewLifetimeControlForViewId(int viewId, out ViewLifetimeControl foundData)
        {
            foreach (var ViewLifetimeControl in SecondaryViews)
            {
                if (ViewLifetimeControl.Id == viewId)
                {
                    foundData = ViewLifetimeControl;
                    return true;
                }
            }
            foundData = null;
            return false;
        }

        private async Task<ViewLifetimeControl> createMainPageAsync()
        {
            ViewLifetimeControl viewControl = null;
            await CoreApplication.CreateNewView().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // This object is used to keep track of the views and important
                // details about the contents of those views across threads
                // In your app, you would probably want to track information
                // like the open document or page inside that window
                viewControl = ViewLifetimeControl.CreateForCurrentView();
                viewControl.Title = DateTime.Now.ToString();
                // Increment the ref count because we just created the view and we have a reference to it                
                viewControl.StartViewInUse();

                var frame = new Frame();
                frame.Navigate(typeof(MainPage), viewControl);
                Window.Current.Content = frame;
                // This is a change from 8.1: In order for the view to be displayed later it needs to be activated.
                Window.Current.Activate();
                //ApplicationView.GetForCurrentView().Title = viewControl.Title;
            });

            ((App)App.Current).SecondaryViews.Add(viewControl);

            return viewControl;
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        //I call this function from MainPage.xaml.cs to try to open a new window
        public async void LoadNewView()
        {
            var selectedView = await createMainPageAsync();
            if (null != selectedView)
            {
                selectedView.StartViewInUse();
                var viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                    selectedView.Id,
                    ViewSizePreference.Default,
                    ApplicationView.GetForCurrentView().Id,
                    ViewSizePreference.Default
                    );

                await selectedView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var currentPage = (MainPage)((Frame)Window.Current.Content).Content;
                    Window.Current.Activate();
                    currentPage.LoadNewFile();
                });

                selectedView.StopViewInUse();
            }
        }
    }
}
