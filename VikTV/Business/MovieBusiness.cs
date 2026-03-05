using System;
using System.Collections.Generic;
using System.Text;
using VikTV.Data.Models;

namespace VikTV.Business
{
    internal class MovieBusiness
    {

        private VikTVContext movieContext;
        public List<Movie> GetAll()
        {
            using (movieContext = new VikTVContext())
            {
                return movieContext.Movies.ToList();
            }
        }
    
        public Movie Get(int id)
        {
            using (movieContext = new VikTVContext())
            {
                return movieContext.Movies.Find(id);
            }
        }

        public void Add(Movie movie)
        {
            using (movieContext = new VikTVContext())
            {
                movieContext.Movies.Add(movie);
                movieContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (movieContext = new VikTVContext())
            {
                var movie = movieContext.Movies.Find(id);
                if (movie != null)
                {
                    movieContext.Movies.Remove(movie);
                    movieContext.SaveChanges();
                }
            }
        }

        //Need to create a new method to update the movie.

    }
}
