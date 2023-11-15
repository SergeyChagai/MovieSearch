using MovieSearch.DIContainer;
using MovieSearch.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieSearch
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();

            //Extraction ViewModel from DIContainer

            var viewModelLocator = Application.Current.Resources["Locator"];
            _viewModel = (viewModelLocator as ViewModelLocator).MainPageViewModel;
            BindingContext = _viewModel;
            _viewModel.SearchDataNeeded += OnSearchDataNeeded;

            //Subscription on GUI Events

            Console.WriteLine($"{this.GetType().Name} has loaded at {DateTime.Now}");
        }

        private void OnSearchDataNeeded()
        {
            _viewModel.SearchTitle = movieTitleEntry.Text;
            _viewModel.SearchGenre = genrePicker.SelectedIndex < 0 ? String.Empty : genrePicker.Items[genrePicker.SelectedIndex];
            _viewModel.SearchActor = actorNameEntry.Text;
        }
    }
}
