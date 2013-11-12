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
    public partial class tunerPage : PhoneApplicationPage
    {
        public tunerPage()
        {
            InitializeComponent();
        }

        private void G_Click(object sender, RoutedEventArgs e)
        {
            G_media.Play();
           
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            C_media.Play();
        }

        private void E_Click(object sender, RoutedEventArgs e)
        {
            E_media.Play();
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            A_media.Play();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void favorite_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FavoritePage.xaml",UriKind.Relative));
        }

    

        private void G_media_MediaEnded(object sender, RoutedEventArgs e)
        {
            if ((bool)keepPlaying.IsChecked)
            {
                G_media.Play();
            }
        }

        private void C_media_MediaEnded(object sender, RoutedEventArgs e)
        {
            if ((bool)keepPlaying.IsChecked)
            {
                C_media.Play();
            }
        }

        private void E_media_MediaEnded(object sender, RoutedEventArgs e)
        {
            if ((bool)keepPlaying.IsChecked)
            {
                E_media.Play();
            }
        }

        private void A_media_MediaEnded(object sender, RoutedEventArgs e)
        {
            if ((bool)keepPlaying.IsChecked)
            {
                A_media.Play();
            }
        }

    }
}