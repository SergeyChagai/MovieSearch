using Microsoft.EntityFrameworkCore;
using MovieSearch.Extensions;
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
        public ICommand SearchCommand { get; set; }
        public string Title { get; set; }
        public string ActorName { get; set; }
        public string GenreName { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }

        private IApplicationContext _applicationContext;

        public MainPageViewModel(IApplicationContext applicationContext)
        {
            SearchCommand = new Command(OnSearchButtonClicked);
            _applicationContext = applicationContext;
            InitializeData();
        }

        private void InitializeData()
        {
            Movies = new ObservableCollection<Movie>(_applicationContext.Movies.ToList());
        }

        private void OnSearchButtonClicked()
        {
            Console.WriteLine($"Button was pressed at {DateTime.Now}");
            Movies.Clear();
            var tmp = _applicationContext.Movies
                .Include(m => m.MovieActors)
                .Include(m => m.MovieGenres);
            var query = tmp
                .Where(m =>
                    String.IsNullOrEmpty(Title) ? true : m.Name.Contains(Title) &&
                    String.IsNullOrEmpty(GenreName) ? true : m.MovieGenres.Any(g => g.Genre.Name.Contains(GenreName)) &&
                    String.IsNullOrEmpty(ActorName) ? true : m.MovieActors.Any(a => a.Actor.Name.Contains(ActorName)))
                .ToList();
            Movies.AddRange(query);
        }
        public void Test()
        {
            ;
        }
    }
}
