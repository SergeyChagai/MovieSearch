using MovieSearch.Models.Interfaces;
using MovieSearch.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MovieSearch.Views
{
    public class RowListView : Label
    {
        public static readonly BindableProperty ActorsProperty = BindableProperty.Create(
            propertyName: "Actors",
            returnType: typeof(List<ActorDto>),
            declaringType: typeof(RowListView),
            propertyChanged: OnActorsPropertyChanged
            );

        public List<ActorDto> Actors
        {
            get => (List<ActorDto>)GetValue(ActorsProperty);
            set => SetValue(ActorsProperty, value);
        }

        public static readonly BindableProperty GenresProperty = BindableProperty.Create(
            propertyName: "Genres",
            returnType: typeof(List<GenreDto>),
            declaringType: typeof(RowListView),
            propertyChanged: OnGenresPropertyChanged
            );

        public List<GenreDto> Genres
        {
            get => (List<GenreDto>)GetValue(GenresProperty);
            set => SetValue(GenresProperty, value);
        }

        public static readonly BindableProperty SeparatorProperty = BindableProperty.Create(
            propertyName: "Separator",
            returnType: typeof(string),
            declaringType: typeof(RowListView)
            );

        public string Separator
        {
            get => (string)GetValue(SeparatorProperty);
            set => SetValue(SeparatorProperty, value);
        }

        private static void OnActorsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null) return;
            var customLabel = (RowListView)bindable;
            customLabel.Text = String.Join(customLabel.Separator, ((List<ActorDto>)newValue).Select(a => a.Name));
        }

        private static void OnGenresPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null) return;
            var customLabel = (RowListView)bindable;
            customLabel.Text = String.Join(customLabel.Separator, ((List<GenreDto>)newValue).Select(g => g.Name));
        }
    }
}
