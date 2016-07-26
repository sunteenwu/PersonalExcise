using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace CFlipview
{
    public class AdsInfo
    {
        public string adSwitch { get; set; } //Time to show up the ad
        public ImageSource imgUri { get; set; } //Image to display
        public string link { get; set; } //Link to redirect user

        public Stretch StretchValue { get; set; }
    }
}
