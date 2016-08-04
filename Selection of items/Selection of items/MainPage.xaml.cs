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

namespace Selection_of_items
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Category> CategoryInfo;
        ObservableCollection<CategoryCodeDB> CategoryCode;
        public MainPage()
        {
            this.InitializeComponent();
            CategoryInfo = new ObservableCollection<Category>
            {
                new Category { CategoryName="Catename1",CategoryDescription="Description1",Picture="Assets/caffe.jpg",},
                new Category { CategoryName="Catename2",CategoryDescription="Description2",Picture="Assets/cafee2.jpg" },
                new Category { CategoryName="Catename3",CategoryDescription="Description3",Picture="Assets/caffe3.jpg" },
            };
            ObservableCollection<CategoryCodeDB> CategoryCode;
            CategoryCode = new ObservableCollection<CategoryCodeDB>
            {
                new CategoryCodeDB {CategoryCode="DBM1" }          
            };
        }

        private void CategoryName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (CategoryCode != null)
            //{
            //    CategoryCode.Clear();
            //}
            //Category selected = CategoryName.SelectedItem as Category;
            //CategoryCode = new ObservableCollection<Category> { selected };
        }
    }
    public class Category
    {
        public string CategoryName { get; set; }
        public string Picture { get; set; }
        public string CategoryDescription { get; set; }        

    }
    public class CategoryCodeDB
    {public string CategoryCode { get; set; }

    }

}
