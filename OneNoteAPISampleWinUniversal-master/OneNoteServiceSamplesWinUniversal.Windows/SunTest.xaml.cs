using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.OnlineId;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OneNoteServiceSamplesWinUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SunTest : Page
    {
        private static readonly OnlineIdAuthenticator Authenticator = new OnlineIdAuthenticator();
        private const string Scopes = "wl.signin";
        private static string _accessToken;
        private const string LiveApiMeUri = "https://apis.live.net/v5.0/me?access_token=";
        public SunTest()
        {
            this.InitializeComponent();
        }

        private async void GetUsername_Click(object sender, RoutedEventArgs e)
        {
            string username= await GetUserName();
            if (username != null)
            {
                txtDatetime.Text += username;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Token expired");
            }
        }

        private async void GetActoken_Click(object sender, RoutedEventArgs e)
        {
            _accessToken = await GetAuthToken();
            txtShowToken.Text += "\n\r" + _accessToken;
            txtDatetime.Text = System.DateTime.Today.ToString();
        }

        internal static async Task<string> GetAuthToken()
        {
            var serviceTicketRequest = new OnlineIdServiceTicketRequest(Scopes, "DELEGATION");
            var result =
                await Authenticator.AuthenticateUserAsync(new[] { serviceTicketRequest }, CredentialPromptType.RetypeCredentials);
            if (result.Tickets[0] != null)
            {
                _accessToken = result.Tickets[0].Value;
                // _refreshToken = result.Tickets[0]
                // _accessTokenExpiration = DateTimeOffset.UtcNow.AddMinutes(AccessTokenApproxExpiresInMinutes);
            }
            return _accessToken;

        }
        internal static async Task<string> GetUserName()
        {
            var uri = new Uri(LiveApiMeUri + _accessToken);
            var client = new HttpClient();
            var result = await client.GetAsync(uri);

            string jsonUserInfo = await result.Content.ReadAsStringAsync();
            if (jsonUserInfo != null)
            {
                var json = JObject.Parse(jsonUserInfo);
                return json["name"].ToString();
            }
            return string.Empty;
        }
    }
}
