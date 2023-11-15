using Microsoft.EntityFrameworkCore;
using MovieSearch.Extentions;
using MovieSearch.Models.Interfaces;
using MovieSearch.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieSearch.ViewModels
{
    public class MainPageViewModel
    {
        public ICommand MovieSearchCommand { get; set; }
        public ObservableCollection<MovieDto> Movies { get; set; }
        public string SearchTitle { get; set; }
        public string SearchActor { get; set; }
        public string SearchGenre { get; set; }

        public event Action SearchDataNeeded;

        private IMovieService _movieService;

        public MainPageViewModel(IMovieService movieService)
        {
            _movieService = movieService;
            MovieSearchCommand = new Command(SearchMoviesAsync);
            Movies = new ObservableCollection<MovieDto>();
        }

        public async void SearchMoviesAsync()
        {
            SearchDataNeeded?.Invoke();
            Movies.Clear();

            //Request for DB
            var movies = await Task.Run(() => _movieService
                .SearchMoviesAsync(SearchTitle, SearchGenre, SearchActor));

            Movies.AddRange(movies);
        }
    }
}
