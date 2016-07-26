using NotificationsExtensions;
using NotificationsExtensions.Badges;
using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
 
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CNotification
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

      

        private void Toast_Click(object sender, RoutedEventArgs e)
        {
            //int num = 5;
            //XmlDocument badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);

            //// Set the value of the badge in the XML to our number
            //XmlElement badgeElement = badgeXml.SelectSingleNode("/badge") as XmlElement;
            //badgeElement.SetAttribute("value", num.ToString());

            //// Create the badge notification
            //BadgeNotification badge = new BadgeNotification(badgeXml);

            //// Create the badge updater for the application
            //BadgeUpdater badgeUpdater = BadgeUpdateManager.CreateBadgeUpdaterForApplication();

            //// And update the badge
            //badgeUpdater.Update(badge);


            //BadgeNumericNotificationContent badge = new BadgeNumericNotificationContent(2);
            //XmlDocument bdoc = badge.GetXml();
            //BadgeNotification bnotification = new BadgeNotification(bdoc);
            //BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(bnotification);

          
            BadgeNumericNotificationContent badgeContent = new BadgeNumericNotificationContent(3);
            BadgeNotification bnotification = new BadgeNotification(badgeContent.GetXml());
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(bnotification);
         
    }

        //private void Tile_Click(object sender, RoutedEventArgs e)
        //{
        //    var badge = new BadgeNumericNotificationContent(2);
        //    AssertXml("<badge version='1' value='2'/>", badge.GetContent());         
        //}
  
        //public static void AssertXml(string expected, string actual)
        //{
        //    MyXmlElement expectedEl = ParseXml(expected);
        //    MyXmlElement actualEl = ParseXml(actual);
        //    AssertXmlElement(expectedEl, actualEl);
        //}
        //private static void AssertXmlElement(MyXmlElement expected, MyXmlElement actual)
        //{
        //    // If both null, good, done
        //    if (expected == null && actual == null)
        //        return;

        //    // If one is null and other isn't, bad
        //    if (expected == null)
        //        Assert.Fail("Expected XML element was null, while actual was initialized");

        //    if (actual == null)
        //        Assert.Fail("Actual XML element was null, while expected was initialized");


        //    // If name doesn't match
        //    Assert.AreEqual(expected.Name, actual.Name, "Element names did not match.");


        //    // If attribute count doesn't match
        //    Assert.AreEqual(expected.Attributes.Count, actual.Attributes.Count, $"Different number of attributes on <{expected.Name}>\n\nExpected: " + AttributesToString(expected.Attributes) + "\nActual: " + AttributesToString(actual.Attributes));


        //    // Make sure attributes match (order does NOT matter)
        //    foreach (MyXmlAttribute expectedAttr in expected.Attributes)
        //    {
        //        var actualAttr = actual.Attributes.FirstOrDefault(i => i.Name.Equals(expectedAttr.Name));

        //        // If didn't find the attribute
        //        if (actualAttr == null)
        //            Assert.Fail("Expected element to have attribute " + expectedAttr.Name + " but it didn't.");

        //        // Make sure value matches
        //        Assert.AreEqual(expectedAttr.Value, actualAttr.Value, $@"Attribute values for ""{expectedAttr.Name}"" didn't match.");
        //    }


        //    // Make sure children elements match (order DOES matter)

        //    // Obtain the child elements (ignore any comments, w
        //    MyXmlElement[] expectedChildren = expected.ChildNodes.ToArray();
        //    MyXmlElement[] actualChildren = actual.ChildNodes.ToArray();

        //    Assert.AreEqual(expectedChildren.Length, actualChildren.Length, "Number of child elements did not match.");


        //    // Compare elements
        //    for (int i = 0; i < expectedChildren.Length; i++)
        //    {
        //        AssertXmlElement(expectedChildren[i], actualChildren[i]);
        //    }
        //}
        //private static void ParseXml(XmlReader reader, MyXmlElement intoElement)
        //{
        //    if (!reader.Read())
        //        return;

        //    while (true)
        //    {
        //        switch (reader.NodeType)
        //        {
        //            // Found child
        //            case XmlNodeType.Element:
        //            case XmlNodeType.Text:
        //                MyXmlElement child = new MyXmlElement();
        //                PopulateElement(reader, child);
        //                ParseXml(reader, child);
        //                intoElement.ChildNodes.Add(child);
        //                break;


        //            // All done
        //            case XmlNodeType.EndElement:
        //                return;
        //        }

        //        if (!reader.Read())
        //            return;
        //    }
        //}
        //private static void PopulateElement(XmlReader reader, MyXmlElement into)
        //{
        //    into.Name = reader.Name;

        //    int attrCount = reader.AttributeCount;
        //    for (int i = 0; i < attrCount; i++)
        //    {
        //        reader.MoveToNextAttribute();

        //        into.Attributes.Add(new MyXmlAttribute()
        //        {
        //            Name = reader.Name,
        //            Value = reader.Value
        //        });
        //    }
        //}
        //private class MyXmlElement
        //{
        //    public string Name { get; set; }

        //    public List<MyXmlElement> ChildNodes { get; private set; } = new List<MyXmlElement>();

        //    public List<MyXmlAttribute> Attributes { get; private set; } = new List<MyXmlAttribute>();
        //}
        //private class MyXmlAttribute
        //{
        //    public string Name { get; set; }
        //    public string Value { get; set; }
        //}
        //private static MyXmlElement ParseXml(string xml)
        //{
        //    XmlReader reader = XmlReader.Create(new StringReader(xml));

        //    MyXmlElement documentElement = new MyXmlElement();

        //    reader.Read();

        //    while (true)
        //    {
        //        if (reader.ReadState == ReadState.EndOfFile)
        //            break;

        //        if (reader.ReadState == ReadState.Error)
        //            throw new Exception("ReadState was Error");

        //        if (reader.NodeType == XmlNodeType.Element)
        //        {
        //            PopulateElement(reader, documentElement);
        //            ParseXml(reader, documentElement);
        //            break;
        //        }

        //        reader.Read();
        //    }

        //    return documentElement;
        //}

        private void ButtonCirclePeek_Click(object sender, RoutedEventArgs e)
        {
            UpdateMedium(new TileBindingContentAdaptive()
            {
                PeekImage = new TilePeekImage()
                {
                    Source = "https://unsplash.it/100",

                    HintCrop = TilePeekImageCrop.Circle
                },

                Children =
                {
                    new AdaptiveText()
                    {
                        Text = "Matt Hidinger sent you a friend request.",
                        HintWrap = true
                    }
                }
            });
        }
        private async void UpdateMedium(TileBindingContentAdaptive mediumContent)
        {
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = mediumContent
                    }
                }
            };

            try
            {
                TileUpdateManager.CreateTileUpdaterForSecondaryTile("SecondaryTile").Update(new TileNotification(content.GetXml()));

                //var badge = new BadgeNumericNotificationContent(2);
                /*XmlDocument bdoc = content.GetXml();*/
                XmlDocument bdoc =BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);
                XmlElement badgeElement = bdoc.SelectSingleNode("/badge") as XmlElement;
                badgeElement.SetAttribute("value", "2");
                BadgeNotification bnotification = new BadgeNotification(bdoc);
                BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(bnotification);
            }

            catch
            {
                SecondaryTile tile = new SecondaryTile("SecondaryTile", "Example", "args", new Uri("ms-appx:///Assets/caffe.png"), TileSize.Default);
                tile.VisualElements.ShowNameOnSquare150x150Logo = true;
                tile.VisualElements.ShowNameOnSquare310x310Logo = true;
                tile.VisualElements.ShowNameOnWide310x150Logo = true;
                tile.VisualElements.BackgroundColor = Colors.Transparent;
                await tile.RequestCreateAsync();

                TileUpdateManager.CreateTileUpdaterForSecondaryTile("SecondaryTile").Update(new TileNotification(content.GetXml()));
            }
        }

        private void ButtonCirclePeek_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {

        }
    }
}
