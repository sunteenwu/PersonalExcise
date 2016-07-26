using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Store;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CColorApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var dic = (ResourceDictionary)XamlReader.Load("<ResourceDictionary x:Key=\"Default\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"><Style TargetType=\"Button\"><Setter Property=\"Background\" Value=\"Red\" /></Style></ResourceDictionary>");
            Resources.MergedDictionaries.Add(dic);

            // loadfile();
            // initLicense();

            //            string rtf =@"{\rtf1\ansi\ansicpg1252\uc1\deff0{\fonttbl
            //{\f0\fnil\fcharset0\fprq2 Arial; }
            //            {\f1\fswiss\fcharset0\fprq2 Tahoma; }
            //            {\f2\fnil\fcharset0\fprq0 Segoe UI; }
            //            {\f3\froman\fcharset2\fprq2 Symbol; }
            //        }
            //{\colortbl;\red0\green0\blue0;\red255\green255\blue255;\red0\green0\blue0;\red255\green18\blue18;\red0\green10\blue255;\red0\green255\blue68;}
            //{\stylesheet{\s0\itap0\nowidctlpar\f0\fs24[Normal];}{\*\cs10\additive Default Paragraph Font;}}
            //{\*\generator TX_RTF32 15.0.530.503;}
            //\deftab1134\paperw11905\paperh16838\margl0\margt0\margr0\margb0\widowctrl\formshade\sectd
            //\headery720\footery720\pgwsxn11905\pghsxn16838\marglsxn0\margtsxn0\margrsxn0\margbsxn0\pard\itap0\nowidctlpar\plain\f1\fs16   \plain\f2\fs16\cf3 Line 1 no formatting\par\par\plain\f2\fs16\cf4 Line 2 Red color\plain\f2\fs16\cf3\par\par\plain\f2\fs16\b\cf4 Line 3 Red Bold\plain\f2\fs16\b\cf3\par\plain\f2\fs16\i\cf5\par Line 4 Blue Italic\par\plain\f2\fs16\i\cf3\par\plain\f2\fs16\ul\cf6 Line 5 Green Underline\plain\f2\fs16\ul\cf3\par\pard\itap0\nowidctlpar}";
            //            Txttarget.Document.SetText(TextSetOptions.FormatRtf, rtf); 

        }

        public async void loadfile()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync("test1.rtf");

            IRandomAccessStream randAccStream = await file.OpenAsync(FileAccessMode.Read);
            Txttarget.Document.LoadFromStream(TextSetOptions.FormatRtf, randAccStream);
        }

        private void BtnChangetextcolor_Click(object sender, RoutedEventArgs e)
        {

            Txttarget.Document.Selection.CharacterFormat.ForegroundColor = Colors.Red;

        }

        private void BtnBold_Click(object sender, RoutedEventArgs e)
        {
            Txttarget.Document.Selection.CharacterFormat.Bold = Windows.UI.Text.FormatEffect.Toggle;
        }

        private async void Loadfile_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync("test1.rtf");

            IRandomAccessStream randAccStream = await file.OpenAsync(FileAccessMode.Read);
            Txttarget.Document.LoadFromStream(TextSetOptions.FormatRtf, randAccStream);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void initLicense()
        {
            //licenseInformation = CurrentApp.LicenseInformation;
            //licenseInformation = CurrentAppSimulator.LicenseInformation;

            var Stringxml = await CurrentApp.GetAppReceiptAsync();
            await new Windows.UI.Popups.MessageDialog("XML APP: " + Stringxml).ShowAsync();
            //varxdoc = newSystem.Xml.Linq.XDocument(xml);
            //...
        }

    }
}
