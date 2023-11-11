using MovieSearch.Models;
using MovieSearch.Models.Interfaces;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieSearch
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "movies.db";
        public string DatabasePath { get; set; }

        public App()
        {
            InitializeComponent();

            DatabasePath = DependencyService.Get<IPath>().GetDatabasePath(DATABASE_NAME);

            // if DB wasn't created (wasn't copied)
            if (!File.Exists(DatabasePath))
            {
                // get assembly
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                // get DB resouce and make the stream
                using (Stream stream = assembly.GetManifestResourceStream($"MovieSearch.{DATABASE_NAME}"))
                {
                    using (FileStream fs = new FileStream(DatabasePath, FileMode.OpenOrCreate))
                    {
                        stream.CopyTo(fs);  // copy DB file on path
                        fs.Flush();
                    }
                }
            }

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
