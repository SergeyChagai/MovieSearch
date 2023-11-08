using Microsoft.EntityFrameworkCore;
using MovieSearch.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSearch.Models
{
    public class ApplicationContext: DbContext, IApplicationContext
    {
        private string _databasePath;

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
