using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CBackground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
           
        }


        private async void OnReg(object sender, RoutedEventArgs e)
        {
            var res = await BackgroundExecutionManager.RequestAccessAsync();
            if (res == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
                res == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                var taskRegistered = false;
                var exampleTaskName = "CaptureUITest";
                foreach (var taskone in BackgroundTaskRegistration.AllTasks)
                {
                    if (taskone.Value.Name == exampleTaskName)
                    {
                        taskRegistered = true;
                        await new MessageDialog("Already register!").ShowAsync();
                        break;
                    }
                }
                if (!taskRegistered)
                {
                    var builder = new BackgroundTaskBuilder();
                    builder.Name = exampleTaskName;
                    builder.TaskEntryPoint = "BackgroundTask.CaptureUITest";
                    builder.SetTrigger(new SystemTrigger(SystemTriggerType.UserAway, false));

                    //builder.SetTrigger(new ApplicationTrigger);
                    // builder.SetTrigger(new TimeTrigger(15, false));
                    await BackgroundExecutionManager.RequestAccessAsync();
                    // builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));
                    BackgroundTaskRegistration task = builder.Register();
                    await new MessageDialog("register!").ShowAsync();
                    task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
                }
            }
        }
        private async void OnUnreg(object sender, RoutedEventArgs e)
        {
            var exampleTaskName = "CaptureUITest";
            foreach (var taskone in BackgroundTaskRegistration.AllTasks)
            {
                if (taskone.Value.Name == exampleTaskName)
                {
                    taskone.Value.Unregister(true);
                    await new MessageDialog("Canceled").ShowAsync();
                }
            }
        }
        private void OnCompleted(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
            //throw new NotImplementedException();
        }

        private void BtnConverttest_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://proxycache.app.iptv.telecom.pt:8080/MeoHandler/ImageProxy.ashx?width=200&url=1/5/55046d06-98e0-4aa3-be7d-f6996152b8ad_c_anatomia-16x9.jpg";
            //  System.Security.SecurityElement.Escape(url);
          var testsstring= WebUtility.UrlEncode(url);
        }
    }
}
