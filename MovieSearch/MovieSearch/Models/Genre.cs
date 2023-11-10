using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSearch.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
    }
}