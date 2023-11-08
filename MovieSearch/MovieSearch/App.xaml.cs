using MovieSearch.Models;
using MovieSearch.Models.Interfaces;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieSearch
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "movies.db";
        public App()
        {
            InitializeComponent();

            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DATABASE_NAME);
            using (var db = new ApplicationContext(dbPath))
            {
                db.Database.EnsureCreated();
                if (db.Movies.Count() == 0)
                {
                    db.Movies.Add(new Movie { Name = "Pirates of the Caribbean", Description = "Blacksmith Will Turner teams up with eccentric pirate \"Captain\" Jack Sparrow to save his love, the governor's daughter, from Jack's former pirate allies, who are now undead." });
                    db.Movies.Add(new Movie { Name = "Hesher", Description = "A young boy has lost his mother and is losing touch with his father and the world around him. Then he meets Hesher who manages to make his life even more chaotic." });
                    db.SaveChanges();
                }
                if (db.Actors.Count() == 0)
                {
                    db.Actors.Add(new Actor { Name = "Johny Depp" });
                    db.SaveChanges();
                }
                if (db.Genres.Count() == 0)
                {
                    db.Genres.Add(new Genre { Name = "Jorney" });
                    db.SaveChanges();
                }
            }
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
