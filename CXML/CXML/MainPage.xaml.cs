using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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

namespace CXML
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Windows.Data.Xml.Dom.XmlDocument doc;
        public MainPage()
        {
            this.InitializeComponent();
            InitXML();
        }

        private async void InitXML()
        {
            try
            {
                //Create a XMLFile folder in your project and add you xml file to this folder
                doc = await LoadXmlFile("XMLFile", "CXmlC.xml");
                RichEditBoxSetMsg(ShowXMLResult, doc.GetXml(), true);
            }
            catch (Exception exp)
            {
                await new Windows.UI.Popups.MessageDialog(exp.ToString()).ShowAsync();
            }
        }

        private async void BtnXmlWrite_Click(object sender, RoutedEventArgs e)
        {
            String input1value = TxtInput.Text;
            if (null != input1value && "" != input1value)
            {
                var value = doc.CreateTextNode(input1value);
                //find input1 tag in header where id=1
                var xpath = "//header[@id='1']/user_input/input1";
                var input1nodes = doc.SelectNodes(xpath);
                for (uint index = 0; index < input1nodes.Length; index++)
                {
                    input1nodes.Item(index).AppendChild(value);
                }
                RichEditBoxSetMsg(ShowXMLResult, doc.GetXml(), true);
            }
            else
            {
                await new Windows.UI.Popups.MessageDialog("Please type in content in the  box firstly.").ShowAsync();
            }
        }
        public static async Task<Windows.Data.Xml.Dom.XmlDocument> LoadXmlFile(String folder, String file)
        {
            Windows.Storage.StorageFolder storageFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(folder);
            Windows.Storage.StorageFile storageFile = await storageFolder.GetFileAsync(file);
            Windows.Data.Xml.Dom.XmlLoadSettings loadSettings = new Windows.Data.Xml.Dom.XmlLoadSettings();
            return await Windows.Data.Xml.Dom.XmlDocument.LoadFromFileAsync(storageFile, loadSettings);
        }
        public static void RichEditBoxSetMsg(RichEditBox richEditBox, String msg, bool fReadOnly)
        {
            richEditBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, msg);
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("CXmlCopy.xml", Windows.Storage.CreationCollisionOption.GenerateUniqueName);
            await doc.SaveToFileAsync(file);
            RichEditBoxSetMsg(ShowXMLResult, "Save to \"" + file.Path + "\" successfully.", true);
        }

        private async void BtnXmlLinq_Click(object sender, RoutedEventArgs e)
        {
            XDocument xdoc = XDocument.Load(@"D:\Customer's\CXML\CXML\bin\x86\Debug\AppX\XMLFile\CXmlC.xml");
            //XElement xe = XElement.Load(@"D:\Customer's\CXML\CXML\bin\x86\Debug\AppX\XMLFile\CXmlC.xml");
            var questionNodes = from n in xdoc.Descendants("header")
                                select n.Element("question").Value;
            List<string> question = questionNodes.ToList<string>();
            System.Diagnostics.Debug.WriteLine(question[0]);
            var Input1Node = from ele in xdoc.Descendants("input1")
                             select ele;
            List<XElement> inputnodelist = Input1Node.ToList<XElement>();
            XElement node1 = inputnodelist[0];
            node1.Add(TxtInput.Text);
            RichEditBoxSetMsg(ShowXMLResult, xdoc.ToString(), true);
            //XElement ele = xdoc.Element("header");
            //System.Diagnostics.Debug.WriteLine(ele.Name);
            //ele.Add(new XElement("user_input",
            //        new XElement("input1", newtext)));
            //IEnumerable<XElement> elements = from ele in xe.Elements("book")
            //                                    select ele;
            //   XElement ele = xdoc.Element("header");
            //   ele.Add(new XElement("user_input",
            //           new XElement("input1","text")));

            //IEnumerable<XElement> elements = from ele in xe.Elements("Topics")
            //                                    select ele;    
            //   foreach(XElement el in elements)
            //   {
            //       System.Diagnostics.Debug.WriteLine(el.Value);
            //   }

            //System.Diagnostics.Debug.WriteLine(elements.Where(elem => elem.Value).Select("a question"));
        }

        private void BtnReader_Click(object sender, RoutedEventArgs e)
        {
            //XmlTextReader reader = new XmlTextReader(@"..\..\Book.xml");
            //           List<BookModel> modelList = new List<BookModel>();
            //           BookModel model = new BookModel();
            //           while (reader.Read())
            //{

            //   if (reader.NodeType == XmlNodeType.Element)
            //                  {
            //                      if (reader.Name == "book")
            //                           {
            //                               model.BookType = reader.GetAttribute(0);
            //                               model.BookISBN = reader.GetAttribute(1);
            //                           }
            //                       if (reader.Name == "title")
            //                           {
            //                               model.BookName = reader.ReadElementString().Trim();
            //                           }
            //                       if (reader.Name == "author")
            //                           {
            //                               model.BookAuthor = reader.ReadElementString().Trim();
            //                           }
            //                       if (reader.Name == "price")
            //                           {
            //                               model.BookPrice = Convert.ToDouble(reader.ReadElementString().Trim());
            //                           }
            //                }

            //   if (reader.NodeType == XmlNodeType.EndElement)
            //        {
            //            modelList.Add(model);
            //            model = new BookModel();
            //        }


            //  }
            //              modelList.RemoveAt(modelList.Count - 1);
            //              this.dgvBookInfo.DataSource = modelList;
        }
    }
}
