using System;
using System.Collections.Generic;
using System.Text;
using MovieSearch.Models;

namespace MovieSearch.ViewModels.DTO
{
    public class MovieDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ActorDto> Actors { get; set; }
        public List<GenreDto> Genres { get; set; }
    }
}
