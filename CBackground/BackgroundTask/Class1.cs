using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.Web.Http;

namespace BackgroundTask
{
    public sealed class CaptureUITest:IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var d = taskInstance.GetDeferral();
            XmlDocument docx = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            var nodes = docx.GetElementsByTagName("text");
            if (nodes.Count > 1)
            {
                XmlElement eltitle = (XmlElement)nodes[0];
                eltitle.AppendChild(docx.CreateTextNode("backgroundtask"));
                XmlElement elCt = (XmlElement)nodes[1];
                elCt.AppendChild(docx.CreateTextNode("background task is trigger"));
            }
            Uri uri = new Uri("http://baidu.com");
            HttpClient httpclient = new HttpClient();
            string result = await httpclient.GetStringAsync(uri);

            ToastNotification toast = new ToastNotification(docx);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
            d.Complete();
        }

    }
}
