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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CGridView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GridviewAdap : Page
    {
        ObservableCollection<ContainerDataItem> Groups1;
        ObservableCollection<ContainerDataItem> Groups2;
        public GridviewAdap()
        {
            this.InitializeComponent();
            this.Groups1 = new ObservableCollection<ContainerDataItem>
            {
                new ContainerDataItem
                {
                    ImagePath="Assets/caffe.jpg",
                    Title="Item1",
                    Description="I have one line"
                },
                new ContainerDataItem
                {
                    ImagePath="Assets/caffe.jpg",
                    Title="Item2",
                    Description="I have two lines,\r\n I have two lines, "
                },
                new ContainerDataItem
                {
                    ImagePath="Assets/caffe.jpg",
                    Title="Item3",
                    Description="I have three lines,\r\nI have three lines,\r\nI have three lines, "
                }
            };
            this.Groups2 = new ObservableCollection<ContainerDataItem>
            {      new ContainerDataItem
                {
                    ImagePath="Assets/caffe.jpg",
                    Title="Item3",
                    Description="I have three lines,\r\nI have three lines,\r\nI have three lines,I have three lines,\r\nI have three lines,\r\nI have three lines "
                },
                 new ContainerDataItem
                {
                    ImagePath="Assets/caffe.jpg",
                    Title="Item1",
                    Description="I have one line"
                },
                new ContainerDataItem
                {
                    ImagePath="Assets/caffe.jpg",
                    Title="Item2",
                    Description="I have two lines,\r\n I have two lines, "
                }
            };
        }
    }
    public class ContainerDataItem
    {
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
