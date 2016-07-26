using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.System;


namespace CHttpClient
{
    class ServerAPI
    {
        // 200 (+User JSON) = success, otherwise APIError JSON
        internal async Task<User> Login(string id, string password)
        {
            LoginPayload payload = new LoginPayload() { LoginId = id, Password = password };
            
            var request = NewRequest(HttpMethod.Post, "login");
            JsonPayload<LoginPayload>(payload, ref request);

            return await Execute<Account>(request, false);
        }

        // 204: success, anything else failure
        internal async Task<Boolean> LogOut()
        {
            return await Execute<Boolean>(NewRequest(HttpMethod.Delete, "login"), true);
        }

        internal async Task<HttpResponseMessage> GetRawResponse()
        {
            return await Execute<HttpResponseMessage>(NewRequest(HttpMethod.Get, "raw/something"), true);
        }

        internal async Task<Int32> GetMeStatusCode()
        {
            return await Execute<Int32>(NewRequest(HttpMethod.Get, "some/intstatus"), true);
        }

        private async Task<RESULT> Execute<RESULT>(HttpRequestMessage request, bool authenticate)
        {
            if (authenticate)
                AuthenticateRequest(ref request); // add auth token to request

            var tcs = new TaskCompletionSource<RESULT>();
            var response = await client.SendAsync(request);

            // TODO: If the RESULT is just HTTPResponseMessage, the rest is unnecessary        

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    // TryParse needs to handle Boolean differently than other types
                    RESULT result = await TryParse<RESULT>(response);
                    tcs.SetResult(result);
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }

            }
            else
            {
                try
                {
                    APIError error = await TryParse<APIError>(response);
                    tcs.SetException(new APIException(error));
                }
                catch (Exception e)
                {
                    tcs.SetException(new APIException("Unknown error"));
                }
            }

            return tcs.Task.Result;
        }
    }
}
