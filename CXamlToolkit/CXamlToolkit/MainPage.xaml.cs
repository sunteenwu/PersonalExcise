using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace CXamlToolkit
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ObservableCollection<Comment> comments = new ObservableCollection<Comment>
            {
                new Comment ("By the way,I have noticed that ..."),
                new Comment("Has this been metioned anywhere before..",
                new List<Comment>
                {
                    new Comment("Delta upgrade..."),
                    new Comment("When only stuff that...",
                        new List<Comment> {
                            new Comment("That's blloby...")},
                        3)},
                2),
                new Comment("Just had to turn off..")
            };

            Treeviewcomment.ItemsSource = comments;
        }


    }

    public class Comment
    {
        public List<Comment> Replies { get; set; }
        public string Body { get; }
        public int Level { get; set; }

        public Comment(string BodyText)
        {
            Body = BodyText;
        }

        public Comment(string BodyText, List<Comment> replies, int level)
        {
            Body = BodyText;
            Replies = replies;
            Level = level;
        }
    }
}
