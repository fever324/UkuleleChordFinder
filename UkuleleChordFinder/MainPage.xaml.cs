using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Advertising.Mobile.UI;
using ProtoBuf;
using System.Threading;
using System.ComponentModel;
using Microsoft.Phone.Tasks;

namespace UkuleleChordFinder
{
    public partial class MainPage : PhoneApplicationPage
    {
        public ObservableCollection<chord> showingChords = new ObservableCollection<chord>();

        public static ObservableCollection<chord> fchord = new ObservableCollection<chord>();
        private Dictionary<string, chord> allChordsDictionary = new Dictionary<string,chord>();
        #region allchordstring
        private string[] allChords = new string[] {
                "a",
                "aminor",
                "g",
                "g11",
                "g13",
                "g6",
                "g7",
                "g7sus",
                "g9",
                "gaug",
                "gdim",
                "gdim7",
                "gmajor7",
                "gminor",
                "gminor11",
                "gminor13",
                "gminor6",
                "gminor7",
                "gminor9",
                "gsus2",
                "gsus4",
                "gsharp",
                "gsharp11",
                "gsharp13",
                "gsharp6",
                "gsharp7",
                "gsharp7sus",
                "gsharp9",
                "gsharpaug",
                "gsharpdim",
                "gsharpdim7",
                "gsharpmajor7",
                "gsharpminor",
                "gsharpminor11",
                "gsharpminor13",
                "gsharpminor6",
                "gsharpminor7",
                "gsharpminor9",
                "gsharpsus2",
                "gsharpsus4",
                "d",
                "d11",
                "d13",
                "d6",
                "d7",
                "d7sus",
                "d9",
                "daug",
                "db11",
                "ddim",
                "ddim7",
                "dmajor7",
                "dminor",
                "dminor11",
                "dminor13",
                "dminor6",
                "dminor7",
                "dminor9",
                "dsus2",
                "dsus4",
                "a11",
                "a13",
                "a6",
                "a7",
                "a7sus",
                "a9",
                "aaug",
                "adim",
                "adim7",
                "amajor7",
                "aminor11",
                "aminor13",
                "aminor6",
                "aminor7",
                "aminor9",
                "asus2",
                "asus4",
                "b",
                "b11",
                "b13",
                "b6",
                "b7",
                "b7sus",
                "b9",
                "baug",
                "bb",
                "bb11",
                "bb13",
                "bb6",
                "bb7",
                "bb7sus",
                "bb9",
                "bbaug",
                "bbdim",
                "bbdim7",
                "bbm9",
                "bbmajor7",
                "bbminor",
                "bbminor11",
                "bbminor13",
                "bbminor6",
                "bbminor7",
                "bbsus2",
                "bbsus4",
                "bdim",
                "bdim7",
                "bmajor7",
                "bminor",
                "bminor11",
                "bminor13",
                "bminor6",
                "bminor7",
                "bminor9",
                "bsus2",
                "bsus4",
                "c",
                "c11",
                "c13",
                "c6",
                "c7",
                "c7sus",
                "c9sus",
                "caug",
                "cdim",
                "cdim7",
                "cmajor7",
                "cminor",
                "cminor11",
                "cminor13",
                "cminor6",
                "cminor7",
                "cminor9",
                "csus2",
                "csus4",
                "csharp",
                "csharp13",
                "csharp6",
                "csharp7",
                "csharp7sus",
                "csharp9",
                "csharpaug",
                "csharpdim",
                "csharpdim7",
                "csharpmajor7",
                "csharpminor",
                "csharpminor11",
                "csharpminor13",
                "csharpminor6",
                "csharpminor7",
                "csharpminor9",
                "csharpsus2",
                "csharpsus4",
                "e",
                "e11",
                "e13",
                "e6",
                "e7",
                "e7sus",
                "e9",
                "eaug",
                "eb",
                "eb11",
                "eb13",
                "eb6",
                "eb7",
                "eb7sus",
                "eb9",
                "ebaug",
                "ebdim",
                "ebdim7",
                "ebm",
                "ebmajor7",
                "ebminor11",
                "ebminor13",
                "ebminor6",
                "ebminor7",
                "ebminor9",
                "ebsus2",
                "ebsus4",
                "edim",
                "edim7",
                "emajor7",
                "eminor",
                "eminor11",
                "eminor13",
                "eminor6",
                "eminor7",
                "eminor9",
                "esus2",
                "esus4",
                "f",
                "f11",
                "f13",
                "f6",
                "f7",
                "f7sus",
                "f9",
                "faug",
                "fdim",
                "fdim7",
                "fmajor7",
                "fminor",
                "fminor11",
                "fminor13",
                "fminor6",
                "fminor7",
                "fminor9",
                "fsus2",
                "fsus4",
                "fsharp",
                "fsharp11",
                "fsharp13",
                "fsharp6",
                "fsharp7",
                "fsharp7sus",
                "fsharp9",
                "fsharpaug",
                "fsharpdim",
                "fsharpdim7",
                "fsharpminor",
                "fsharpmajor7",
                "fsharpminor11",
                "fsharpminor13",
                "fsharpminor6",
                "fsharpminor7",
                "fsharpminro9",
                "fsharpsus2",
                "fsharpsus4",
                 };
        #endregion allchordstring

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
            Loaded += new RoutedEventHandler( MainPage_Loaded);
        }
        /// <summary>
        /// Page loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Load favorite chords
            loadMyFavorite();

            if (allChordsDictionary.Count == 0)
            {
                //add all chords to allchord dictionary
                foreach (string a in allChords)
                {
                    allChordsDictionary.Add(a, new chord { chordName = a, chordUrl = @"/Resources/Chords/" + a + @".JPG" });
                }
            }
            BindData();
        }

        private void loadAllChords()
        {
            showingChords = new ObservableCollection<chord>(allChordsDictionary.Values.ToList()); 
        }

        private void BindData()
        {
           ChordsListBox.ItemsSource = showingChords;
        }

        private void loadCurrentChord(string input)
        {
            //clean and clear
            input = input.Replace(" ",string.Empty).ToLower();
            showingChords.Clear();
            if (input.IndexOf("#") != -1)
            {
                input = input.Replace("#", "sharp");
            }
            var  chords = allChordsDictionary.Values.Where(x=> x.chordName.Contains(input)).ToList();
            showingChords = new ObservableCollection<chord>(chords);
            BindData();
        }


        #region searbox functions
        private void searchForChords()
        {
                if (searchBox.Text == "")
                {
                    loadAllChords();
                }
                else
                {
                    loadCurrentChord(searchBox.Text);
                }
                scrolltoTop();
        }



        private void searchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchBox.SelectAll();
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Focus();
                searchForChords();
            }
        }

        private void scrolltoTop()
        {
           if(ChordsListBox.Items.Count!= 0)
            ChordsListBox.ScrollIntoView(ChordsListBox.Items[0]);
        }
        #endregion


        private void help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you want to look up c# chord, simply type 'c#' or 'csharp' into the search box. \n"+
                            "By holding each chord, you will have the option to add to your favorite chords."+
                            "\n\n NOTE: Please use the letter b as flat. \n eg. E flat is Eb");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            searchForChords();
        }

        private void loadMyFavorite()
        {
            fchord = favorite.loadMyFavorite();
        }

        private void AddtoMyFavorite_Click(object sender, RoutedEventArgs e)
        {
            if (!fchord.Contains((chord)(sender as MenuItem).DataContext))
            {
                fchord.Add((chord)(sender as MenuItem).DataContext);
                //save to file
                favorite.saveFchord();
            }
        }

        private void favorite_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FavoritePage.xaml", UriKind.Relative));
        }
        private void Tuner_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/tunerPage.xaml", UriKind.Relative));
        }

        private void RateAPP_Click(object sender, EventArgs e)
        {
            Microsoft.Phone.Tasks.MarketplaceReviewTask rate = new Microsoft.Phone.Tasks.MarketplaceReviewTask();
            rate.Show();
        }

        private void QT_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailCompose = new EmailComposeTask();
            emailCompose.Subject = "Question/Suggestion for Ukulele Chord Finder";
            emailCompose.Body = "Hi,\n I'm using Ukulele Chord Finder.";
            emailCompose.To = "fever324@gmail.com";

            emailCompose.Show();
        }

        
    }


    [ProtoContract]
    public class chord{
        public chord()
        {
        }
        [ProtoMember(1)]
        public string chordName{get; set;}

        [ProtoMember(2)]
        public string chordUrl{get;set;}
    }


  
}