using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;
using System.IO;
using System.Collections.ObjectModel;
using ProtoBuf;

namespace UkuleleChordFinder
{
    class favorite
    {
        public static ObservableCollection<chord> loadMyFavorite()
        {
            using (IsolatedStorageFile myIso = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIso.FileExists("favorite.txt"))
                {
                    using (IsolatedStorageFileStream stream = myIso.OpenFile("favorite.txt", FileMode.Open))
                    {
                        return Serializer.Deserialize<ObservableCollection<chord>>(stream);
                    }
                }
                else
                {

                    using (IsolatedStorageFileStream stream = myIso.CreateFile("favorite.txt"))
                    {
                        return Serializer.Deserialize<ObservableCollection<chord>>(stream);
                    }
                }
            }
        }

        public static void saveFchord()
        {
            using (IsolatedStorageFile myIso = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIso.OpenFile("favorite.txt", FileMode.Create))
                {
                    Serializer.Serialize(stream, MainPage.fchord);
                }
            }
        }

        
    }
}
