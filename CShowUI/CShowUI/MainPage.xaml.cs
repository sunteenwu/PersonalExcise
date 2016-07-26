using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CShowUI;
using System.Threading.Tasks;
using ClassLib;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using Windows.ApplicationModel.Background;
using System.Net.Http;
using System.Text.RegularExpressions;
using Windows.Data.Json;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CShowUI
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
        private async void testsocket_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6530/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                var reponse = await client.PostAsync("Token", new FormUrlEncodedContent(
                                         new[]
                                         {
                                                new KeyValuePair<string,string>("grant_type","password"),
                                                new KeyValuePair<string,string>("username","xak"),
                                                new KeyValuePair<string,string>("password","Password1!"),
                                         }
             ));

                var tokenModel = reponse.Content.ReadAsStringAsync().Result;
                var tokenString = Regex.Match(tokenModel, ".*\"access_token\":\"(.*?)\".*", RegexOptions.IgnoreCase).Groups[1].Value;

                //here

                client.DefaultRequestHeaders.Add("Authorization", tokenString);
                var response = await client.GetAsync(String.Format("api/values/"));
                var results = JsonObject.Parse(await response.Content.ReadAsStringAsync());
            }
        }
        public void RegistBackgroundtask()
        {
            var taskRegistered = false;
            var exampleTaskName = "BackgroundTask";
            foreach (var task0 in BackgroundTaskRegistration.AllTasks)
            {
                if (task0.Value.Name == exampleTaskName)
                {
                    taskRegistered = true;
                    break;
                }
            }
            var builder = new BackgroundTaskBuilder();
            builder.Name = exampleTaskName;
            builder.TaskEntryPoint = "Mytask.BackgroundTask";
            builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
            builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));
            BackgroundTaskRegistration task = builder.Register();
        }

      

        private void CancelBckground_Click(object sender, RoutedEventArgs e)
        {
            var exampleTaskName = "BackgroundTask";
            foreach (var task0 in BackgroundTaskRegistration.AllTasks)
            {
                if (task0.Value.Name == exampleTaskName)
                {
                      task0.Value.Unregister(true);
                }
            }
        }

        private void RegistBackground_Click(object sender, RoutedEventArgs e)
        {
            RegistBackgroundtask();
        }

        private  void InsertDirectData_Click(object sender, RoutedEventArgs e)
        {
            MyDatabase d = new MyDatabase();
            d.savedata("new entry3");
            //d.savedata("another entry3");
        }

        
    }

}
