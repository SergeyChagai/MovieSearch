using MovieSearch.Models.Interfaces;
using MovieSearch.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieSearch.Models.Services
{
    public class MovieDtoMapper: IMovieDtoMapper
    {
        public List<MovieDto> MapMoviesToMoviesDtos(List<Movie> movies)
        {
            return movies.Select(movie => new MovieDto
            {
                Name = movie.Name,
                Description = movie.Description,
                Actors = movie.MovieActors.Select(ma => new ActorDto { Name = ma.Actor.Name}).ToList(),
                Genres = movie.MovieGenres.Select(mg => new GenreDto { Name = mg.Genre.Name }).ToList()
            }).ToList();
        }
    }
}
