using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;

namespace CompuSight.Metro.Samples.HttpClient
{
    public static class HttpClientExtensions
    {

        static async Task<string> GetStringTaskProvider(Task<HttpResponseMessage> httpOperation, CancellationToken token, IProgress<int> progressCallback)
        {
            int offset = 0;

            var result = string.Empty;

            var responseBuffer = new byte[500];

            // Execute the http request and get the initial response
            // NOTE: We might receive a network error here
            var httpInitialResponse = await httpOperation;

            using (var responseStream = await httpInitialResponse.Content.ReadAsStreamAsync())
            {
                int read;

                do
                {
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }

                    read = await responseStream.ReadAsync(responseBuffer, 0, responseBuffer.Length);

                    result += Encoding.UTF8.GetString(responseBuffer, 0, read);

                    offset += read;

                    progressCallback.Report(offset);

                } while (read != 0);
            }

            return result;
        }

        public static IAsyncOperationWithProgress<string, int> GetStringAsyncWithProgress(this System.Net.Http.HttpClient client, HttpRequestMessage request)
        {
            return client.GetStringAsyncWithProgress(request, CancellationToken.None);
        }

        public static IAsyncOperationWithProgress<string, int> GetStringAsyncWithProgress(this System.Net.Http.HttpClient client, HttpRequestMessage request, CancellationToken cancelToken)
        {
            var operation = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancelToken);

            return AsyncInfo.Run<string, int>((token, progress) =>
            {
                if (cancelToken != CancellationToken.None) token = cancelToken;

                return GetStringTaskProvider(operation, token, progress);
            });
        }
    }
}
