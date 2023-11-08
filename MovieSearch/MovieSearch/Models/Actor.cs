using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSearch.Models
{
    [Table("Actors")]
    public class Actor
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}