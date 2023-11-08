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
            var viewModelLocator = Application.Current.Resources["Locator"];
            _viewModel = (viewModelLocator as ViewModelLocator).MainPageViewModel;
            BindingContext = _viewModel;
            movieTitleEntry.PropertyChanged += MovieTitleEntry_PropertyChanged;
        }

        private void MovieTitleEntry_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _viewModel.Test();
        }
    }
}
