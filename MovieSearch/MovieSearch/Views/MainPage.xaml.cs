using MovieSearch.DIContainer;
using MovieSearch.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

            //Subscription on GUI Events

            movieTitleEntry.Completed += OnMovieTitleEntryCompleted;
            actorNameEntry.Completed += OnActorNameEntryCompleted;
            genrePicker.SelectedIndexChanged += OnGenrePickerSelectedIndexChanged;

            Console.WriteLine($"{this.GetType().Name} has loaded at {DateTime.Now}");
        }

        private void OnMovieTitleEntryCompleted(object sender, EventArgs e)
        {
            var entry = (Entry)sender;
            _viewModel.Title = entry.Text;
        }
        
        private void OnActorNameEntryCompleted(object sender, EventArgs e)
        {
            var entry = (Entry)sender;
            _viewModel.ActorName = entry.Text;
        }

        private void OnGenrePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            _viewModel.GenreName = picker.Items.ElementAt(picker.SelectedIndex);
        }

    }
}
