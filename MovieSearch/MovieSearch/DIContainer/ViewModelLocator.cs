using CommonServiceLocator;
using MovieSearch.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSearch.DIContainer
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            AutoFacContainer.Initialize();
        }

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }
    }
}
