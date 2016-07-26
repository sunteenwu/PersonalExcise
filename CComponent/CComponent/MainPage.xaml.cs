using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CComponent
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

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            var cobject =new  WindowsRuntimeComponent1.Class1();
            var num = cobject.LogCalc(21.5);
            var pmdevice=cobject.PMDeviceApiGet(1,)
            ResultText.Text = num.ToString();

            //var dmd = new Class1();
            //int result1 = dmd.PMDeviceApiInit();
            //if (result1 == 0)
            //{
            //    uint index = ((3) << 16) + (3);
            //    byte[] p = new byte[32];
            //    int size = 32;
            //    int n = 0;

            //    int res = dmd.PMDeviceApiGet(index, p, size, n);
            //    this.Edit1.Text = "res : " + res;
            //    dmd.PMDeviceApiDeinit();
            //}
            //else
            //{
            //    this.Edit1.Text = "fail : " + result1;
            //}

        }
    }
}
