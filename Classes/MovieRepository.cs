using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class MovieRepository : IRepository<Movie>
    {
        private List<Movie> movieList = new List<Movie>();
        
        public void Insert(Movie entity)
        {
            movieList.Add(entity);
        }

        public List<Movie> List()
        {
            return movieList;
        }

        public int NextId()
        {
            return movieList.Count;
        }

        public void Remove(int id)
        {
            movieList[id].Remove();
        }

        public Movie returnById(int id)
        {
            return movieList[id];
        }

        public void Update(int id, Movie entity)
        {
            movieList[id] = entity;
        }
    }
}