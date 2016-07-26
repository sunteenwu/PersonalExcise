using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using ClassLib;
using Windows.Storage;

namespace Mytask
{
    public sealed class BackgroundTask : IBackgroundTask
    {
        public   void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();
            MyDatabase d = new MyDatabase();
             //d.savedata("new entry2");
            //d.savedata("another entry");
            //StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            //以下是从后台发送通知，证明backgroundtask正在运行。可以忽略
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList textElements = toastXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toastXml.CreateTextNode("Background Task"));
            textElements[1].AppendChild(toastXml.CreateTextNode("I'm message from your background task!"));
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));
            _deferral.Complete();

        }
    }
}
