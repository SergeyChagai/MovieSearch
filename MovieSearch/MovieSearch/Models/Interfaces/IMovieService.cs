using MovieSearch.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieSearch.Models.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieDto>> SearchMoviesAsync(string title, string actorName, string genreName);
    }
}
