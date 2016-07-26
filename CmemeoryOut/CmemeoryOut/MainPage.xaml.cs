using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CmemeoryOut
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

        //protected void GetMemoryLimit()
        //{
            

        //}

        private void Btnmemory_Click(object sender, RoutedEventArgs e)
        {
           
           var limits = MemoryManager.AppMemoryUsageLimit;
            var usingm= MemoryManager.AppMemoryUsage;
            var MBget = limits / 1024 / 1024;
            var um = usingm / 1024 / 1024;
            txtshow.Text ="limit is"+ MBget.ToString()+"MB"+"/n";
            txtshow.Text += "have using" + um.ToString() + "MB" + "/n";

        }

        private void BtnRequire_Click(object sender, RoutedEventArgs e)
        {
            var size = long.Parse(txtmemory.Text);
            byte[] buffer=new byte[size*size*100];
            var mb = size * size*100 / 1024 / 1024;
            txtshow.Text +="using"+ mb.ToString()+"MB";
        }
    }
}
