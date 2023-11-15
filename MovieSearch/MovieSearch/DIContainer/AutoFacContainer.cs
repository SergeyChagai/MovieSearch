using Autofac;
using Autofac.Core;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Microsoft.Extensions.DependencyModel;
using MovieSearch.Models;
using MovieSearch.Models.Interfaces;
using MovieSearch.Models.Services;
using MovieSearch.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace MovieSearch.DIContainer
{
    public class AutoFacContainer
    {
        private const string DATABASE_NAME = "movies.db";
        public static void Initialize()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Register(c => new ApplicationContext(((App)Application.Current).DatabasePath)).As<IApplicationContext>();
            containerBuilder.RegisterType<MovieDtoMapper>().As<IMovieDtoMapper>();
            containerBuilder.RegisterType<MovieService>().As<IMovieService>();
            containerBuilder.RegisterType<MainPageViewModel>().AsSelf();

            IContainer container = containerBuilder.Build();

            AutofacServiceLocator autofacServiceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);
        }
    }
}
