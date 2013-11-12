using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace UkuleleChordFinder
{
    public partial class FavoritePage : PhoneApplicationPage
    {
        public FavoritePage()
        {
            InitializeComponent();
            BindData();
        }


        private void RemovefromMyFavorite_Click(object sender, RoutedEventArgs e)
        {
            MainPage.fchord.Remove((chord)(sender as MenuItem).DataContext);
            favorite.saveFchord();
        }

        private void BindData()
        {
            ChordsListBox.ItemsSource = MainPage.fchord;
        }

        private void help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By holding at each chord, you will have the option to remove from favorite chords.");
        
        }

        private void Search_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Tuner_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/tunerPage.xaml", UriKind.Relative));

        }
    }
}