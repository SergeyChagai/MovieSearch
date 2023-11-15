using Microsoft.EntityFrameworkCore;
using MovieSearch.Models.Interfaces;
using MovieSearch.ViewModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MovieSearch.Models.Services
{
    public class MovieService: IMovieService
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IMovieDtoMapper _movieDtoMapper;

        public MovieService(IApplicationContext applicationContext, IMovieDtoMapper movieDtoMapper)
        {
            _applicationContext = applicationContext;
            _movieDtoMapper = movieDtoMapper;
        }

        public async Task<List<MovieDto>> SearchMoviesAsync(string title, string genreName, string actorName)
        {
            var query = await _applicationContext.Movies
               .Include(m => m.MovieActors).ThenInclude(ma => ma.Actor)
               .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
               .Where(m =>
               (string.IsNullOrEmpty(title) || m.Name.ToLower().Contains(title.ToLower())) &&
               (string.IsNullOrEmpty(genreName) || m.MovieGenres.Any(g => g.Genre.Name.ToLower().Contains(genreName.ToLower()))) &&
               (string.IsNullOrEmpty(actorName) || m.MovieActors.Any(a => a.Actor.Name.ToLower().Contains(actorName.ToLower()))))
           .ToListAsync();

            return _movieDtoMapper.MapMoviesToMoviesDtos(query);
        }

        
    }
}
