using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSearch.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
