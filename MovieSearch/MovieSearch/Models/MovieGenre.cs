using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSearch.Models
{
    public class MovieGenre
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        public Movie Movie { get; set; }
        public Genre Genre { get; set; }

        public override string ToString()
        {
            return Genre.Name;
        }
    }
}
