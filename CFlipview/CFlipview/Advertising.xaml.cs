using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CFlipview
{
    public sealed partial class Advertising : UserControl, INotifyPropertyChanged
    {
        private AdsCollection ads = new AdsCollection();

        double firstSwitch = 0;

        private DispatcherTimer timer;

        public ObservableCollection<AdsInfo> Source
        {
            get { return ads.AdsDataCollection; }
            set
            {
                ads.Copy(value);
                NotifyPropertyChanged();
            }
        }

        public Advertising()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        public Advertising(string type)
        {
            this.InitializeComponent();
            this.DataContext = this;

            //if (type == "Widget")
            //    ScreenResolutionUtilities.SetControlRelativeDimensions(this.flipView, 0.92, 0.28);
        }

        public async void setHomeAdvertising(XmlReader xml, string adsSwitch)
        {

            XmlReader subtree = xml.ReadSubtree();

            while (subtree.Read())
            {
                if (subtree.NodeType == XmlNodeType.Element)
                {
                    if (subtree.Name == "BANNER")
                    {
                        AdsInfo adsIT = new AdsInfo();

                        string bannerSwitch = subtree.GetAttribute("SWITCH");

                        adsIT.adSwitch = setAdsSwitch(bannerSwitch, adsSwitch);

                        string uri = await ImageAttacher.getImageURI(subtree, "default");

                        adsIT.imgUri = ImageAttacher.setImage(uri);

                        adsIT.link = subtree.GetAttribute("LINK");

                        adsIT.StretchValue = Windows.UI.Xaml.Media.Stretch.UniformToFill;

                        ads.AddAdv(adsIT);

                    }
                }
            }
        }

        public async void setBannerAds(string Page)
        {
            var query = DescriptionsDAO.conn.Query<SQLBanners>("SELECT * FROM SQLBanners WHERE Page=?", Page);
            if (query.Count != 0)
            {
                foreach (var banner in query)
                {
                    AdsInfo adsIT = new Utilities.HomeResources.AdsInfo();
                    adsIT.adSwitch = banner.Switch;
                    adsIT.imgUri = await ImageAttacher.setImageFromValue(banner.MobV);
                    adsIT.link = banner.Link;
                    adsIT.StretchValue = Windows.UI.Xaml.Media.Stretch.Uniform;
                    ads.AddAdv(adsIT);
                }
            }
        }

        private string setAdsSwitch(string bSw, string aSw)
        {
            if (bSw == null && aSw != null)
                return aSw;
            else if (bSw != null || aSw != null)
                return bSw;
            else
                return "";
        }

        public void setTimer()
        {
            string sw = ads.getSwitchAdStringAt(0);
            if (sw != "")
            {
                firstSwitch = ads.getSwitchAdDoubleAt(0);
                currentItemLink = ads.getLinkAdAt(0);

                timer = new DispatcherTimer()
                {
                    Interval = TimeSpan.FromSeconds(firstSwitch)
                };
                timer.Tick += ChangeImage;
                timer.Start();
            }
        }

        public string currentItemLink { get; set; }

        private void ChangeImage(object sender, object o)
        {
            var newItemIndex = (flipView.SelectedIndex + 1) % ads.Count;
            flipView.SelectedIndex = newItemIndex;

            timer.Stop();
            timer.Interval = TimeSpan.FromSeconds(ads.getSwitchAdDoubleAt(newItemIndex));
            currentItemLink = ads.getLinkAdAt(newItemIndex);
            timer.Start();
        }

        public void Clear()
        {
            ads.Clear();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // PropertyChanged event triggering method.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
