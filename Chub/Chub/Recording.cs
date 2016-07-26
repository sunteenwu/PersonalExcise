using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chub
{
    public class Recording
    {
        public string ArtistName { get; set; }
        public string CompositionName { get; set; }
        public DateTime ReleaseDateTime { get; set; }
        public Uri ImageUri { get; set; }

        public Recording(string name, string composition, DateTime when, string prefixedFilename)
        {
            this.ArtistName = name;
            this.CompositionName = composition;
            this.ReleaseDateTime = when;
            //   string prefixedFilename = "ms-appx://Quickstart/Assets/" + filename;
            ImageUri = new Uri(prefixedFilename);
        }

        public string OneLineSummary
        {
            get
            {
                return $"{this.CompositionName} by {this.ArtistName}, released: "
                    + this.ReleaseDateTime.ToString("d");
            }
        }
    }

    public class RecordingViewModel
    {
        List<Recording> recordings;

        public RecordingViewModel()
        {
            recordings = new List<Recording>();
            recordings.Add(new Recording("Wolfgang Amadeus Mozart", "Andante in C for Piano", new DateTime(1761, 1, 1), "http://csimg.koopkeus.nl/srv/NL/29023839m56849/T/340x340/C/FFFFFF/url/mozart.jpg"));
            recordings.Add(new Recording("Nickleback", "Gotta be Somebody", new DateTime(2003, 8, 21), "http://images4.fanpop.com/image/photos/16500000/n-nickelback-16579001-634-634.jpg"));
        }

        public List<Recording> RecordingList { get { return this.recordings; } }
    }
}
