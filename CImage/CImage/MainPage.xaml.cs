using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CImage
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

        private void Tiletest_Click(object sender, RoutedEventArgs e)
        {
            string localImageURL = "ms-appx:///Assets/MyImage70x70.png";

            XmlDocument _myXML = new XmlDocument();

            string PeekSlide =
                                  @"<tile>
                       <visual>
                      <binding template=""TileMedium"" branding=""name"">
                       <image src=""{0}""  placement=""peek"" hint-overlay=""20""/>
                      <image  src=""{1}"" placement=""background""/>
                      </binding>
                      </binding>
                      </visual>
                      </tile>";

            var _myTile = string.Format(PeekSlide, localImageURL);
            _myXML.LoadXml(_myTile);
        }
    }
}
