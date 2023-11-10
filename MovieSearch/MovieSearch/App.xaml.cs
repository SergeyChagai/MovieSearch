using MovieSearch.Models;
using MovieSearch.Models.Interfaces;
using SQLitePCL;
using System;
using System.Collections.Generic;
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
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var actionGenre = new Genre { Name = "Action" };
                var dramaGenre = new Genre { Name = "Drama" };
                var comedyGenre = new Genre { Name = "Comedy" };

                db.Genres.AddRange(actionGenre, dramaGenre, comedyGenre);
                db.SaveChanges();

                var actor1 = new Actor { Name = "Johny Depp" };
                var actor2 = new Actor { Name = "Kira Nitley" };
                var actor3 = new Actor { Name = "Orlando Blum" };
                var actor4 = new Actor { Name = "Joseph Gordon-Levitt" };

                db.Actors.AddRange(actor1, actor2, actor3);
                db.SaveChanges();

                var movie1 = new Movie
                {
                    Name = "Pirates of the Caribbean",
                    Description = "Blacksmith Will Turner teams up with eccentric pirate \"Captain\" Jack Sparrow to save his love, the governor's daughter, from Jack's former pirate allies, who are now undead.",
                };
                var movie2 = new Movie
                {
                    Name = "Hesher",
                    Description = "A young boy has lost his mother and is losing touch with his father and the world around him. Then he meets Hesher who manages to make his life even more chaotic."
                };

                db.Movies.AddRange(movie1, movie2);
                db.SaveChanges();

                movie1.MovieGenres.Add(new MovieGenre { GenreId = actionGenre.Id, Genre = actionGenre, MovieId = 0, Movie = movie1});
                movie1.MovieGenres.Add(new MovieGenre { GenreId = comedyGenre.Id, Genre = comedyGenre, MovieId = 0, Movie = movie1 });
                movie1.MovieActors.Add(new MovieActor { ActorId = actor1.Id, Actor = actor1, MovieId = 0, Movie = movie1 });
                movie1.MovieActors.Add(new MovieActor { ActorId = actor2.Id, Actor = actor2, MovieId = 0, Movie = movie1 });
                movie1.MovieActors.Add(new MovieActor { ActorId = actor3.Id, Actor = actor3, MovieId = 0, Movie = movie1 });

                movie2.MovieGenres.Add(new MovieGenre { GenreId = actionGenre.Id, Genre = actionGenre, MovieId = 1, Movie = movie2 });
                movie2.MovieGenres.Add(new MovieGenre { GenreId = dramaGenre.Id, Genre = dramaGenre, MovieId = 1, Movie = movie2 });
                movie2.MovieActors.Add(new MovieActor { ActorId = actor4.Id, Actor = actor4, MovieId = 1, Movie = movie2 });

                db.SaveChanges();
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
