using Microsoft.EntityFrameworkCore;
using MovieSearch.Extentions;
using MovieSearch.Models;
using MovieSearch.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieSearch.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();

        private IApplicationContext _applicationContext;

        public MainPageViewModel(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async void SearchMoviesAsync(string title, string actorName, string genreName)
        {
            Movies.Clear();

            //Request for DB
            var query = await _applicationContext.Movies
                .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                .Where(m =>
                (string.IsNullOrEmpty(title) || m.Name.ToLower().Contains(title.ToLower())) &&
                (string.IsNullOrEmpty(genreName) || m.MovieGenres.Any(g => g.Genre.Name.ToLower().Contains(genreName.ToLower()))) &&
                (string.IsNullOrEmpty(actorName) || m.MovieActors.Any(a => a.Actor.Name.ToLower().Contains(actorName.ToLower()))))
            .ToListAsync();

            Device.BeginInvokeOnMainThread(() =>
            {
                Movies.AddRange(query);

                //Add string properties for models
                foreach (var movie in Movies)
                {
                    movie.Actors = String.Join(", ", movie.MovieActors);
                    movie.Genres = String.Join(", ", movie.MovieGenres);
                }
            });
        }
    }
}
