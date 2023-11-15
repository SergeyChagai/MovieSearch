using MovieSearch.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSearch.Models.Interfaces
{
    public interface IMovieDtoMapper
    {
        List<MovieDto> MapMoviesToMoviesDtos(List<Movie> movies);
    }
}
