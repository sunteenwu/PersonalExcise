using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.Midi;
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

namespace CdeviceInfo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
             this.getPort();
        }
        private async void getPort()
        {
            IMidiOutPort _out = await Singleton.getMidiPort();
            txtStatus.Text = _out.DeviceId.ToString();
        }    
      
    }

    public class Singleton
    {
        protected static Singleton _obj;
        public static IMidiOutPort _outputPort;
        static string portName = "Microsoft GS Wavetable Synth";
        static DeviceInformationCollection _outputDevices;

        private Singleton()
        {

        }
        public static Singleton GetObject()
        {
            if (_obj == null)
            {
                _obj = new Singleton();
            }
            return _obj;
        }
        public void Print(string s)
        {
            // Console.WriteLine(s);
            getMidiPort();
        }
         
        public static async Task<IMidiOutPort> getMidiPort()
        {
            if (_outputPort != null)
            {
                return _outputPort;
            }
            // Find all output MIDI devices
            string midiOutputQueryString = MidiOutPort.GetDeviceSelector();
            _outputDevices = await DeviceInformation.FindAllAsync(midiOutputQueryString);


            // Return if no external devices are connected, and GS synth is not detected
            if (_outputDevices.Count == 0)
            {
                //txtStatus.Text = "Please connect at least one external MIDI device for this demo to work correctly";
                return null;
            }

            if (_outputPort != null)
            {
                _outputPort.Dispose();
            }

            foreach (DeviceInformation deviceInfo in _outputDevices)
            {
                if (deviceInfo.Name == portName)
                {
                    _outputPort = await MidiOutPort.FromIdAsync(deviceInfo.Id);

                    if (_outputPort == null)
                    {
                        return null;
                    }
                }
            }
            //_outputPort = await MidiOutPort.FromIdAsync(deviceInfo.Id);
            return _outputPort;
            //return Task.FromResult<>_outputPort;
        }
    }
}
