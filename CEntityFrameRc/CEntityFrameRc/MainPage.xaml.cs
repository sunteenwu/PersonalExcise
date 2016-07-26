﻿using CEntityFrameRc.Model;
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

namespace CEntityFrameRc
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
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new UserContext())
            {
                var user = new UserProfile
                {
                    UserId = UserId.Text,
                    FullName = FullName.Text,
                    Username=UserName.Text,
                    Email = Email.Text,                    
                };

                db.UserProfiles.Add(user);
                db.SaveChanges();
                 
                Users.ItemsSource = db.UserProfiles.OrderBy(c => c.FullName).ToList();

            }
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            using (var db = new UserContext())
            {
                Users.ItemsSource = db.UserProfiles.OrderBy(c => c.UserId).ToList();
                ListFriend.ItemsSource = db.UserProfiles.OrderBy(c => c.UserId).ToList();
            }
        }
    }
}
