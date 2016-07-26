using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Editing;
using Windows.Media.Playback;
using Windows.Media.Streaming.Adaptive;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CMedia
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       // private Dictionary<TimedTextSource, Uri> ttsMap = new Dictionary<TimedTextSource, Uri>();
        public MainPage()
        {
            this.InitializeComponent();
            ReadLyric();
        }
        private async void ReadLyric()
        {
            var source = MediaSource.CreateFromUri(new Uri("https://mediaplatstorage1.blob.core.windows.net/windows-universal-samples-media/elephantsdream-clip-h264_sd-aac_eng-aac_spa-aac_eng_commentary-srt_eng-srt_por-srt_swe.mkv"));
            var playbackItem = new MediaPlaybackItem(source);

            playbackItem.TimedMetadataTracksChanged += (sender, args) =>
            {
                var changedTrackIndex = args.Index;
                var changedTrack = playbackItem.TimedMetadataTracks[(int)changedTrackIndex];

                if (changedTrack.Language == "eng")
                    playbackItem.TimedMetadataTracks.SetPresentationMode((uint)changedTrackIndex, TimedMetadataTrackPresentationMode.PlatformPresented);
            };
            this.media.SetPlaybackSource(playbackItem);   
            // var ttmSource = TimedTextSource.CreateFromUri(new Uri("ms-appx:///assets/ElephantsDream-Clip-SRT_en.srt"));
            // source.ExternalTimedTextSources.Add(ttmSource);
            //    var ttmSource = TimedTextSource.CreateFromUri(new Uri("ms-appx:///assets/JiangNan.ttm"));
            // var mediaSource = MediaSource.CreateFromAdaptiveMediaSource(astream);
            //    //var mediaSource = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/casting.mp4"));
            //    mediaSource.ExternalTimedTextSources.Add(ttmSource);
            //  var mediaElement = new MediaPlaybackItem(mediaSource);
            //  media.SetPlaybackSource(mediaElement);          
        }
     

            // Create the media source and supplement with external timed text sources
            //var source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/casting.mp4"));

            //var ttsEnUri = new Uri("ms-appx:///Assets/Media/ElephantsDream-Clip-SRT_en.srt");
            //var ttsEn = TimedTextSource.CreateFromUri(ttsEnUri);
            //ttsMap[ttsEn] = ttsEnUri;

            //var ttsPtUri = new Uri("ms-appx:///Assets/Media/ElephantsDream-Clip-SRT_pt.srt");
            //var ttsPt = TimedTextSource.CreateFromUri(ttsPtUri);
            //ttsMap[ttsPt] = ttsPtUri;

            //var ttsSvUri = new Uri("ms-appx:///Assets/Media/ElephantsDream-Clip-SRT_sv.srt");
            //var ttsSv = TimedTextSource.CreateFromUri(ttsSvUri);
            //ttsMap[ttsSv] = ttsSvUri;

            //ttsEn.Resolved += Tts_Resolved;
            //ttsPt.Resolved += Tts_Resolved;
            //ttsSv.Resolved += Tts_Resolved;

            //source.ExternalTimedTextSources.Add(ttsEn);
            //source.ExternalTimedTextSources.Add(ttsPt);
            //source.ExternalTimedTextSources.Add(ttsSv);

            //// Create the playback item from the source
            //var playbackItem = new MediaPlaybackItem(source);

            //// Present the first track
            //playbackItem.TimedMetadataTracksChanged += (sender, args) =>
            //{
            //    playbackItem.TimedMetadataTracks.SetPresentationMode(0, TimedMetadataTrackPresentationMode.PlatformPresented);
            //};

            //// Set the source to start playback of the item
            //this.mediaElement.SetPlaybackSource(playbackItem);
        }

        //private void Tts_Resolved(TimedTextSource sender, TimedTextSourceResolveResultEventArgs args)
        //{
        //    var ttsUri = ttsMap[sender];

        //    // Handle errors
        //    if (args.Error != null)
        //    {
        //        var ignoreAwaitWarning = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        //        {
        //            //rootPage.NotifyUser("Error resolving track " + ttsUri + " due to error " + args.Error.ErrorCode, NotifyType.ErrorMessage);
        //        });
        //        return;
        //    }

        //    // Update label manually since the external SRT does not contain it
        //    var ttsUriString = ttsUri.AbsoluteUri;
        //    if (ttsUriString.Contains("_en"))
        //        args.Tracks[0].Label = "English";
        //    else if (ttsUriString.Contains("_pt"))
        //        args.Tracks[0].Label = "Portuguese";
        //    else if (ttsUriString.Contains("_sv"))
        //        args.Tracks[0].Label = "Swedish";
        //}
    
}
