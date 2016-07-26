using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace C8._1Hyperlink
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
        private void BtnSettext_Click(object sender, RoutedEventArgs e)
        {
             HyperLinkedTextBlock.SetText(myTextBlock, "Gün geçmiyor ki teknoloji sitelerine bir yenisi eklenmesin.Mesela; http://www.teknomeknotekno.com , http://www.takinotekinotekno.net , Facebook sayfamsı şu sayfa http://www.facebook.com/teknotekinotakino , Youtube sayfamsı şu hesap http://www.youtube.com/teknotekinotakino ve Twitter hesabımsı bu sayfa http://www.twitter.com/teknotekinotakino bunlardan sadece bazıları :)");

            //HyperLinkedTextBlock.SetText(myTextBlock, "aatest http://www.bing.com  aa http://www.baidu.com ");
        }


    }
    public class HyperLinkedTextBlock
    {
        public static string GetText(TextBlock element)
        {
            if (element != null)
                return element.GetValue(ArticleContentProperty) as string;
            return string.Empty;
        }

        public static void SetText(TextBlock element, string value)
        {
            if (element != null)
                element.SetValue(ArticleContentProperty, value);
        }

        public static readonly DependencyProperty ArticleContentProperty =
            DependencyProperty.RegisterAttached(
                "Text",
                typeof(string),
                typeof(HyperLinkedTextBlock),
                new PropertyMetadata(null, OnInlineListPropertyChanged));

        private static void OnInlineListPropertyChanged(DependencyObject obj,
             DependencyPropertyChangedEventArgs e)
        {
            var tb = obj as TextBlock;
            if (tb == null)
                return;
            string text = e.NewValue as string;
            tb.Inlines.Clear();

            if (text.ToLower().Contains("http:") || text.ToLower().Contains("www."))
                AddInlineControls(tb, SplitSpace(text));
            else
                tb.Inlines.Add(GetRunControl(text));
        }

        private static void AddInlineControls(TextBlock textBlock, string[] splittedString)
        {
            for (int i = 0; i < splittedString.Length; i++)
            {
                string tmp = splittedString[i];
                if (tmp.ToLower().StartsWith("http:") || tmp.ToLower().StartsWith("www."))
                    textBlock.Inlines.Add(GetHyperLink(tmp));
                else
                    textBlock.Inlines.Add(GetRunControl(tmp));
            }
        }

        private static Hyperlink GetHyperLink(string uri)
        {
            if (uri.ToLower().StartsWith("www."))
                uri = "http://" + uri;

            Hyperlink hyper = new Hyperlink();
            hyper.NavigateUri = new Uri(uri);
            hyper.Inlines.Add(GetRunControl(uri));
            return hyper;
        }

        private static Run GetRunControl(string text)
        {
            Run run = new Run();
            run.Text = text + " ";
            return run;
        }

        private static string[] SplitSpace(string val)
        {
            string[] splittedVal = val.Split(new string[] { " " }, StringSplitOptions.None);
            return splittedVal;
        }


    }
}
