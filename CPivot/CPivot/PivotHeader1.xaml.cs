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
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CPivot
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PivotHeader1 : Page
    {
        public PivotHeader1()
        {
            this.InitializeComponent();
            List<pivotdata> pivotdatas = new List<pivotdata>() { new pivotdata() { TitleHeaders = "I'm header1" },
            new pivotdata() { TitleHeaders="I'm header2"}, new pivotdata() { TitleHeaders="I'm header3"} };
            mainContentPivot.ItemsSource = pivotdatas;
        }

        private void HeaderManpulation_Click(object sender, RoutedEventArgs e)
        {
            // PivotHeaderItem item =new PivotHeaderItem();
            //item.Content = "I'm header1";
            // PivotItem item2 = new PivotItem();
            //PivotItem pivotitem=mainContentPivot.ContainerFromItem(item) as PivotItem;
            //PivotItem pivotitem2  = mainContentPivot.ContainerFromIndex(1) as PivotItem;
            //System.Diagnostics.Debug.WriteLine(pivotitem2.Content.ToString());
            //System.Diagnostics.Debug.WriteLine(pivotitem2.Header.ToString());
            //System.Diagnostics.Debug.WriteLine(pivotitem2.ToString());       

            // PivotHeaderItem headeritem = mainContentPivot.GroupHeaderContainerFromItemContainer( as PivotHeaderItem;
            //item2.Header = item;
            // mainContentPivot.ItemFromContainer("I'm header1");

            //PivotItem item1 = mainContentPivot.Items[0] as PivotItem;
            //StackPanel headitem = item1.Header as StackPanel;
            //TextBlock txtblock = headitem.Children[0] as TextBlock;
            //System.Diagnostics.Debug.WriteLine(txtblock.Text);
            PivotItem pivotitem1 = mainContentPivot.ContainerFromIndex(1) as PivotItem;
           
            var headeritem2 = pivotitem1.Header;
           // PivotHeaderItem headeritem = mainContentPivot.GroupHeaderContainerFromItemContainer(pivotitem1) as PivotHeaderItem;
           // System.Diagnostics.Debug.WriteLine(headeritem2.ActualWidth);
            //System.Diagnostics.Debug.WriteLine(pivotitem1.Content);

            // System.Diagnostics.Debug.WriteLine(controls[0].ToString());
            // var test = controls.Count;



            //PivotItem pivotitem1 = simplepivot.ContainerFromIndex(1) as PivotItem;
            //System.Diagnostics.Debug.WriteLine(pivotitem1.Content.ToString());
            //PivotItem pivotitem3 = simplepivot.Items[0] as PivotItem;
            //System.Diagnostics.Debug.WriteLine(pivotitem3.Content.ToString());
            //TextBlock headitem1 = pivotitem1.Header as TextBlock;
            //System.Diagnostics.Debug.WriteLine(HeaderManpulation.ActualWidth);       



        }
    }

    public class pivotdata
    {
        public string TitleHeaders { get; set; }
    }

}
