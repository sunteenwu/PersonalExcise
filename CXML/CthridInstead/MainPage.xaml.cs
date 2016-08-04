using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CthridInstead
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Windows.Data.Xml.Dom.XmlDocument doc;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void BtnGetNode_Click(object sender, RoutedEventArgs e)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            WebRequest request = HttpWebRequest.Create("http://www.eurogymnasium-waldenburg.de/egw_content/Stunden_Vertretungsplan/home.html");
            WebResponse response = await request.GetResponseAsync();
            Stream stream = response.GetResponseStream();
            var result = "";
            using (StreamReader sr = new StreamReader(stream))
            {
                result = sr.ReadToEnd();
            }
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(result);
    
            var node = doc.DocumentNode.SelectSingleNode("/html/body[@class='ui-widget']/div[@id='main']/div[@id='vplan']/div[@id='bereichaktionen']");
            var node2 = doc.GetElementbyId("title");


            RichEditBoxSetMsg(ShowXMLResult, node.InnerText, true);

            //htmlDoc.LoadHtml("http://www.eurogymnasium-waldenburg.de/egw_content/Stunden_Vertretungsplan/home.html");
            //RichEditBoxSetMsg(ShowXMLResult, htmlDoc.GetElementbyId("title").InnerText, true);
            //HtmlNode docNode = htmlDoc.DocumentNode.SelectSingleNode("/html/body[@class='ui-widget']/div[@id='main']/div[@id='vplan']/div[@id='bereichaktionen']");
            //RichEditBoxSetMsg(ShowXMLResult, docNode.InnerText, true);

            //doc = await XmlDocument.LoadFromUriAsync(new Uri("http://www.eurogymnasium-waldenburg.de/egw_content/Stunden_Vertretungsplan/home.html"));

            //   HttpClient httpclient = new HttpClient();
            //   HttpResponseMessage response = await httpclient.GetAsync(new Uri("http://www.eurogymnasium-waldenburg.de/egw_content/Stunden_Vertretungsplan/home.html"));
            //   string content = await response.Content.ReadAsStringAsync();

            //RichEditBoxSetMsg(ShowXMLResult, content.ToString(), true);
            //doc = await LoadXmlFile("XMLFile", "CXml.xml");
            //RichEditBoxSetMsg(ShowXMLResult, doc.GetXml(), true);
            //doc.LoadXml(content);

        }
        public static void RichEditBoxSetMsg(RichEditBox richEditBox, String msg, bool fReadOnly)
        {
            richEditBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, msg);
        }
        public static async Task<Windows.Data.Xml.Dom.XmlDocument> LoadXmlFile(String folder, String file)
        {
            Windows.Storage.StorageFolder storageFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(folder);
            Windows.Storage.StorageFile storageFile = await storageFolder.GetFileAsync(file);
            Windows.Data.Xml.Dom.XmlLoadSettings loadSettings = new Windows.Data.Xml.Dom.XmlLoadSettings();
            return await Windows.Data.Xml.Dom.XmlDocument.LoadFromFileAsync(storageFile, loadSettings);
        }
    }
}
