﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Data.Xml.Dom;
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

namespace HtmlRtfDemo
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

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = new MainPageViewModel();
        }
    }

    public class HtmlToRtfConverter
    {


        public static string GetHtml(DependencyObject obj)
        {
            return (string)obj.GetValue(HtmlProperty);
        }

        public static void SetHtml(DependencyObject obj, string value)
        {
            obj.SetValue(HtmlProperty, value);
        }

        // Using a DependencyProperty as the backing store for Html.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HtmlProperty =
            DependencyProperty.RegisterAttached("Html", typeof(string), typeof(HtmlToRtfConverter), new PropertyMetadata("", OnHtmlChanged));

        private static void OnHtmlChanged(DependencyObject sender, DependencyPropertyChangedEventArgs eventArgs)
        {
            RichTextBlock parent = (RichTextBlock)sender;
            parent.Blocks.Clear();

            XmlDocument document = new XmlDocument();
            document.LoadXml((string)eventArgs.NewValue);

            ParseElement((XmlElement)(document.GetElementsByTagName("body")[0]), new RichTextBlockTextContainer(parent));
        }

        private static void ParseElement(XmlElement element, ITextContainer parent)
        {
            foreach (var child in element.ChildNodes)
            {
                if (child is Windows.Data.Xml.Dom.XmlText)
                {
                    if (string.IsNullOrEmpty(child.InnerText) ||
                        child.InnerText == "\n")
                    {
                        continue;
                    }

                    parent.Add(new Run { Text = child.InnerText });
                }
                else if (child is XmlElement)
                {
                    XmlElement e = (XmlElement)child;
                    switch (e.TagName.ToUpper())
                    {
                        case "P":
                            var paragraph = new Paragraph();
                            parent.Add(paragraph);
                            ParseElement(e, new ParagraphTextContainer(paragraph));
                            break;
                        case "STRONG":
                            var bold = new Bold();
                            parent.Add(bold);
                            ParseElement(e, new SpanTextContainer(bold));
                            break;
                        case "U":
                            var underline = new Underline();
                            parent.Add(underline);
                            ParseElement(e, new SpanTextContainer(underline));
                            break;
                        case "A":
                            ParseElement(e, parent);
                            break;
                        case "BR":
                            parent.Add(new LineBreak());
                            break;
                    }
                }


            }
        }

        private interface ITextContainer
        {
            void Add(Inline text);
            void Add(Block paragraph);
        }

        private sealed class SpanTextContainer : ITextContainer
        {
            private readonly Span _span;

            public SpanTextContainer(Span span)
            {
                _span = span;
            }

            public void Add(Inline text)
            {
                _span.Inlines.Add(text);
            }

            public void Add(Block paragraph)
            {
                throw new NotSupportedException();
            }
        }

        private sealed class ParagraphTextContainer : ITextContainer
        {
            private readonly Paragraph _block;

            public ParagraphTextContainer(Paragraph block)
            {
                _block = block;
            }

            public void Add(Inline text)
            {
                _block.Inlines.Add(text);
            }

            public void Add(Block paragraph)
            {
                throw new NotSupportedException();
            }
        }

        private sealed class RichTextBlockTextContainer : ITextContainer
        {
            private readonly RichTextBlock _richTextBlock;

            public RichTextBlockTextContainer(RichTextBlock richTextBlock)
            {
                _richTextBlock = richTextBlock;
            }

            public void Add(Inline text)
            {
                //throw new NotSupportedException();
                var paragraph = new Paragraph();
                paragraph.Inlines.Add(text);

                _richTextBlock.Blocks.Add(paragraph);
            }

            public void Add(Block paragraph)
            {
                _richTextBlock.Blocks.Add(paragraph);
            }
        }
        
    }
}
