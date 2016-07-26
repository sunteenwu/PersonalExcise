using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CHyperLink
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            jsonCall();
        }
        public static BitmapImage ImageFromRelativePath(FrameworkElement parent, string path)
        {
            var uri = new Uri(parent.BaseUri, path);
            BitmapImage result = new BitmapImage();
            result.UriSource = uri;
            return result;
        }
        public async void jsonCall()
        {
            List<Result> listResult = new List<Result>();

            var client = new HttpClient();
            String jsonString = await client.GetStringAsync(new Uri("http://api-public.guidebox.com/v1.43/Tunisia/rKgEWJbFg0kgEHrcGXPKhPDo0XtTafyC/movies/all/250/250"));
            System.Diagnostics.Debug.WriteLine(JsonValue.Parse(jsonString).ValueType);
            JsonObject root = JsonValue.Parse(jsonString).GetObject();
            JsonArray res = root.GetNamedArray("results");

            for (uint i = 0; i < res.Count; i++)
            {
                JsonObject con = res.GetObjectAt(i);
                System.Diagnostics.Debug.WriteLine(con);
                String id = con.GetNamedNumber("id").ToString();
                String title = con.GetNamedString("title");
                string release_year = con.GetNamedNumber("release_year").ToString();
                string themoviedb = con.GetNamedNumber("themoviedb").ToString();
                string original_title = con.GetNamedString("original_title");
                JsonArray alt = con.GetNamedArray("alternate_titles");
                String name = "-";
                if (alt.Count != 0)
                {
                    name = alt.GetStringAt(0);
                    for (uint j = 1; j < alt.Count; j++)
                    {
                        name = name + ", " + alt.GetStringAt(j);
                    }
                }
                string imdb = con.GetNamedString("imdb");
                string pre_order = con.GetNamedBoolean("pre_order").ToString();
                string in_theaters = con.GetNamedBoolean("in_theaters").ToString();
                string release_date = con.GetNamedString("release_date");
                string rating = con.GetNamedString("rating");
                string rottentomatoes = con.GetNamedNumber("rottentomatoes").ToString();
                string freebase = con.GetNamedString("freebase");
                string wikipedia_id = con.GetNamedNumber("wikipedia_id").ToString();
              //System.Diagnostics.Debug.WriteLine("------------------------------"+con.GetNamedValue("metacritic").ValueType);

                //  string metacritic = con.GetNamedString("metacritic").TrimStart('"').TrimEnd('"');
                //MediaElement metacritic= VideoFromRelativePath(this, con.GetNamedValue("metacritic").ValueType.ToString());
                //JsonValue sss = con.GetNamedValue("common_sense_media");
                //string s = sss.GetString();
                string common_sense_media = con.GetNamedValue("common_sense_media").ToString().TrimStart('"').TrimEnd('"');
                //string common_sense_media = con.GetNamedValue("common_sense_media").GetString();
                string metacritic = con.GetNamedValue("metacritic").ToString().TrimStart('"').TrimEnd('"'); 
                //if(common_sense_media==null || metacritic==null)
                //{

                //}
               System.Diagnostics.Debug.WriteLine(metacritic);
              //System.Diagnostics.Debug.WriteLine(id + ":"+common_sense_media);
                // Uri Common_sense_media = con.GetNamedValue("Common_sense_media").ToString();
                //   string Common_sense_media = con.GetNamedValue("Common_sense_media").ToString();
                //string Common_sense_media = con.GetNamedString("metacritic");
                //System.Diagnostics.Debug.WriteLine("-------------"+Common_sense_media);
                BitmapImage Poster_120x171 = ImageFromRelativePath(this, con.GetNamedString("poster_120x171"));
                BitmapImage poster_240x342 = ImageFromRelativePath(this, con.GetNamedString("poster_240x342"));
                BitmapImage poster_400x570 = ImageFromRelativePath(this, con.GetNamedString("poster_400x570"));
                list.Items.Add(new Result
                {
                    Id = id,
                    Title = title,
                    Themoviedb = themoviedb,
                    Original_title = original_title,
                    Alternate_titles = name,
                    Imdb = imdb,
                    Pre_order = pre_order,
                    In_theaters = in_theaters,
                    Release_date = release_date,
                    Rating = rating,
                    Rottentomatoes = rottentomatoes,
                    Freebase = freebase,
                    Wikipedia_id = wikipedia_id,

                    Common_sense_media = common_sense_media,
                    Metacritic = metacritic,
                    Poster = Poster_120x171,
                    Poster_240x342 = poster_240x342,
                    Poster_400x570 = poster_400x570
                });


            }

        }
    }
}
