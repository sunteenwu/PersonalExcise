using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Graphics.DirectX.Direct3D11;
using Windows.Media.Effects;
using Windows.Media.MediaProperties; 
using Windows.Graphics.Imaging;
using System.Runtime.InteropServices;

namespace CustomEffect
{

    public sealed class ExampleVideoEffect : IBasicVideoEffect
    {    private int frameCount;
        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public double FadeValue
        {
            get
            {
                object val;
                if (configuration != null && configuration.TryGetValue("FadeValue", out val))
                {
                    return (double)val;
                }
                return .5;
            }
        }

        public IReadOnlyList<VideoEncodingProperties> SupportedEncodingProperties
        {
            get
            {
                var encodingProperties = new VideoEncodingProperties();
                encodingProperties.Subtype = "ARGB32";
                return new List<VideoEncodingProperties>() { encodingProperties };

                // If the list is empty, the encoding type will be ARGB32.
                // return new List<VideoEncodingProperties>();
            }
        }

    

        public bool TimeIndependent
        {
            get
            {
               return true;
            }
        }

        public MediaMemoryTypes SupportedMemoryTypes
        {
            get
            {
                 return MediaMemoryTypes.Cpu;  
            }
        }

        public void Close(MediaEffectClosedReason reason)
        {
            throw new NotImplementedException();
        }

        public void DiscardQueuedFrames()
        {
            //throw new NotImplementedException();
            frameCount = 0;
        }

        public void ProcessFrame(ProcessVideoFrameContext context)
        {
            using (BitmapBuffer buffer = context.InputFrame.SoftwareBitmap.LockBuffer(BitmapBufferAccessMode.Read))
            using (BitmapBuffer targetBuffer = context.OutputFrame.SoftwareBitmap.LockBuffer(BitmapBufferAccessMode.Write))
            {
                using (var reference = buffer.CreateReference())
                using (var targetReference = targetBuffer.CreateReference())
                {
                    byte* dataInBytes;
                    uint capacity;
                    ((IMemoryBufferByteAccess)reference).GetBuffer(out dataInBytes, out capacity);

                    byte* targetDataInBytes;
                    uint targetCapacity;
                    ((IMemoryBufferByteAccess)targetReference).GetBuffer(out targetDataInBytes, out targetCapacity);

                    var fadeValue = FadeValue;

                    // Fill-in the BGRA plane
                    BitmapPlaneDescription bufferLayout = buffer.GetPlaneDescription(0);
                    for (int i = 0; i < bufferLayout.Height; i++)
                    {
                        for (int j = 0; j < bufferLayout.Width; j++)
                        {

                            byte value = (byte)((float)j / bufferLayout.Width * 255);

                            int bytesPerPixel = 4;
                            if (encodingProperties.Subtype != "ARGB32")
                            {
                                // If you support other encodings, adjust index into the buffer accordingly
                            }


                            int idx = bufferLayout.StartIndex + bufferLayout.Stride * i + bytesPerPixel * j;

                            targetDataInBytes[idx + 0] = (byte)(fadeValue * (float)dataInBytes[idx + 0]);
                            targetDataInBytes[idx + 1] = (byte)(fadeValue * (float)dataInBytes[idx + 1]);
                            targetDataInBytes[idx + 2] = (byte)(fadeValue * (float)dataInBytes[idx + 2]);
                            targetDataInBytes[idx + 3] = dataInBytes[idx + 3];
                        }
                    }
                }
            }
        }

        public void SetEncodingProperties(VideoEncodingProperties encodingProperties, IDirect3DDevice device)
        {
            throw new NotImplementedException();
        }

        private VideoEncodingProperties encodingProperties;
        public void SetProperties(IPropertySet configuration)
        {
            // throw new NotImplementedException();
            this.encodingProperties = encodingProperties;
        }

        [ComImport]
        [Guid("5B0D3235-4DBA-4D44-865E-8F1D0E4FD04D")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        unsafe interface IMemoryBufferByteAccess
        {
            void GetBuffer(out byte* buffer, out uint capacity);
        }
    }
}
