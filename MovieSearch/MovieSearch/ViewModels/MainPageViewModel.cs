using MovieSearch.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieSearch.ViewModels
{
    public class MainPageViewModel
    {
        private IApplicationContext _applicationContext;
        private ICommand _searchCommand;
        public MainPageViewModel(IApplicationContext applicationContext)
        {
            _searchCommand = new Command(OnSearchButtonClicked);
            _applicationContext = applicationContext;
            InitializeData();
        }

        private void InitializeData()
        {
            var movies = _applicationContext.Movies.ToList();
            var actors = _applicationContext.Actors.ToList();
            var genres = _applicationContext.Genres.ToList();
        }

        private void OnSearchButtonClicked()
        {

        }
        public void Test()
        {
            ;
        }
    }
}
