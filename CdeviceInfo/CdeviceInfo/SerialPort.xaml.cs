using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CdeviceInfo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SerialPort : Page
    {
        private DataWriter dataWriteObject;

        public SerialPort()
        {
            this.InitializeComponent();
        }

        public SerialDevice serialPort { get; private set; }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var deviceSelector = SerialDevice.GetDeviceSelector("COM5");
                var devices = await DeviceInformation.FindAllAsync(deviceSelector);
                if (devices.Any())
                {
                    var deviceId = devices.First().Id;
                    serialPort = await SerialDevice.FromIdAsync(deviceId);

                    if (serialPort != null)
                    {
                        serialPort.BaudRate = 9600;
                        serialPort.StopBits = SerialStopBitCount.One;
                        serialPort.DataBits = 8;
                        serialPort.Parity = SerialParity.None;
                        serialPort.Handshake = SerialHandshake.None;

                        //dataWriteObject = new DataWriter(serialPort.OutputStream);
                        //await WriteAsync(WriteCancellationTokenSource.Token);

                        //dataReaderObject = new DataReader(serialPort.InputStream);
                        //await ReadAsync(ReadCancellationTokenSource.Token);

                    }
                }


            }
            catch (Exception ex)
            {
                TxtRespuesta.Text = ex.Message;
            }
            finally
            {
                serialPort.Dispose();
                serialPort = null;
            }
        }

        //private async Task ReadAsync(CancellationToken cancellationToken)
        //{

        //    Task<UInt32> loadAsyncTask;

        //    uint ReadBufferLength = 1024;

        //    // Don't start any IO if we canceled the task
        //    lock (ReadCancelLock)
        //    {
        //        cancellationToken.ThrowIfCancellationRequested();

        //        // Cancellation Token will be used so we can stop the task operation explicitly
        //        // The completion function should still be called so that we can properly handle a canceled task
        //        dataReaderObject.InputStreamOptions = InputStreamOptions.Partial;
        //        loadAsyncTask = dataReaderObject.LoadAsync(ReadBufferLength).AsTask(cancellationToken);
        //    }

        //    UInt32 bytesRead = await loadAsyncTask;
        //    if (bytesRead > 0)
        //    {
        //        TxtRespuesta.Text += dataReaderObject.ReadString(bytesRead);
        //    }
        //    //rootPage.NotifyUser("Read completed - " + bytesRead.ToString() + " bytes were read", NotifyType.StatusMessage);
        //}

        //private async Task WriteAsync(CancellationToken cancellationToken)
        //{

        //    Task<UInt32> storeAsyncTask;
        //    String cadena = "@GI;23;";
        //    char[] buffer = cadena.ToArray();
        //    cadena.CopyTo(0, buffer, 0, cadena.Length);
        //    String InputString = new string(buffer);
        //    dataWriteObject.WriteString(InputString);

        //    // Don't start any IO if we canceled the task
        //    lock (WriteCancelLock)
        //    {
        //        cancellationToken.ThrowIfCancellationRequested();
        //        storeAsyncTask = dataWriteObject.StoreAsync().AsTask(cancellationToken);
        //    }

        //    UInt32 bytesWritten = await storeAsyncTask;
        //    if (bytesWritten > 0)
        //    {

        //    }
        //    //rootPage.NotifyUser("Write completed - " + bytesWritten.ToString() + " bytes written", NotifyType.StatusMessage);
        //}
    }
}
