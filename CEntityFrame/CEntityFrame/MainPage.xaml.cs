using CEntityFrame.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CEntityFrame
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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new SkillsContext())
            {
                Skills.ItemsSource = db.Skills.ToList();
                Contacts.ItemsSource = db.Contacts.OrderBy(c => c.FirstName).ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new SkillsContext())
            {
                var contact = new Contact
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Email = Email.Text,
                    Skill = Skills.SelectedValue.ToString()
                };

                db.Contacts.Add(contact);
                db.SaveChanges();

                Skills.SelectedValue = null;
                FirstName.Text = string.Empty;
                LastName.Text = string.Empty;
                Email.Text = string.Empty;
                Contacts.ItemsSource = db.Contacts.OrderBy(c => c.FirstName).ToList();

            }
        }
    }
}
