using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using HtmlAgilityPack;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace CnblogsApp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Grid_Loading(FrameworkElement sender, object args)
        {
            WebRequest request = HttpWebRequest.Create("http://www.cnblogs.com/aggsite/headline");
            WebResponse response = await request.GetResponseAsync();
            Stream stream = response.GetResponseStream();
            var result = "";
            using (StreamReader sr = new StreamReader(stream))
            {
                result = sr.ReadToEnd();
            }
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(result);
            var nodes=doc.DocumentNode.SelectNodes("//*[@id=\"post_list\"]/div/div/h3");
            foreach (var item in nodes)
            {
                ListViewItem lv = new ListViewItem();
                lv.Content = item.InnerText;
                cnblogs.Items.Add(lv);
            }     
        }
    }
}
