using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSearch.Models
{
    [Table("Movie")]
    public class Movie
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Genre> genres { get; set; }
        public List<Actor> actors {get;set;}
    }
}
