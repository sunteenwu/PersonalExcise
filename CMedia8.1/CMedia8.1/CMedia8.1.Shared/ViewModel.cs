using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.UI.Xaml.Controls;

namespace ViewModels
{
    class MyViewModel: NotificationBase
    {
        private MediaCapture _mediaCapture;
        public MediaCapture MediaCapture
        {
            get
            {
                if (_mediaCapture == null) _mediaCapture = new MediaCapture();
                return _mediaCapture;
            }
            set
            {
                //SetProperty( ref _mediaCapture, value,() => MediaCapture);
                SetProperty(ref _mediaCapture, value);
                //_mediaCapture = value;
            }
        }
        //private CaptureElement _captureElement;
        //public CaptureElement CaptureElement
        //{
        //    get
        //    {
        //        if (_captureElement == null) _captureElement = new CaptureElement();
        //        return _captureElement;
        //    }
        //    set
        //    {
        //        // Set(() => CaptureElement, ref _captureElement, value);
        //        SetProperty(ref _captureElement, value);
        //    }
        //}

        public MyViewModel()
        {
            ConfigureMedia();
        }

        private async void ConfigureMedia()
        {
            await MediaCapture.InitializeAsync();
           // CaptureElement.Source = MediaCapture;
            await MediaCapture.StartPreviewAsync();

        }

    }
}
