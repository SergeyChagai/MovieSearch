using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieSearch.Models
{
    public class DatabaseService
    {
        SQLiteConnection database;

        #region DB Creation
        public DatabaseService(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Movie>();
            database.CreateTable<Actor>();
            database.CreateTable<Genre>();
        }
        #endregion

        #region DB Reading
        public IEnumerable<Movie> GetMovies()
        {
            return database.Table<Movie>().ToList();
        }
        public IEnumerable<Actor> GetActors()
        {
            return database.Table<Actor>().ToList();
        }
        public IEnumerable<Genre> GetGenres()
        {
            return database.Table<Genre>().ToList();
        }
        public Movie GetMovie(int id)
        {
            return database.Get<Movie>(id);
        }
        public Actor GetActor(int id)
        {
            return database.Get<Actor>(id);
        }
        public Genre GetGenre(int id)
        {
            return database.Get<Genre>(id);
        }
        #endregion

        #region DB Updating
        public int SaveMovie(Movie item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public int SaveActor(Actor item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public int SaveGenre(Genre item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        #endregion

        #region DB Deleting Item
        public int DeleteMovie(int id)
        {
            return database.Delete<Movie>(id);
        }
        public int DeleteActor(int id)
        {
            return database.Delete<Actor>(id);
        }
        public int DeleteGenre(int id)
        {
            return database.Delete<Genre>(id);
        }
        #endregion
    }
}
