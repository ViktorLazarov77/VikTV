using System;
using System.Collections.Generic;
using System.Text;
using VikTV.Data.Models;

namespace VikTV.Business
{
    internal class GenreBusiness
    {

        private VikTVContext genreContext;

        public List<Genre> GetAll()
        {
            using (genreContext = new VikTVContext())
            {
                return genreContext.Genres.ToList();
            }
        }

        public Genre Get(int id)
        {
            using (genreContext = new VikTVContext())
            {
                return genreContext.Genres.Find(id);
            }
        }

        public void Add(Genre genre)
        {
            using (genreContext = new VikTVContext())
            {
                genreContext.Genres.Add(genre);
                genreContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (genreContext = new VikTVContext())
            {
                var genre = genreContext.Genres.Find(id);
                if (genre != null)
                {
                    genreContext.Genres.Remove(genre);
                    genreContext.SaveChanges();
                }
            }
        }

        public void Update(Genre genre)
        {
            using (genreContext = new VikTVContext())
            {
                var existingGenre = genreContext.Genres.Find(genre.GenreId);
                if (existingGenre != null)
                {
                    existingGenre.GenreName = genre.GenreName;
                    genreContext.SaveChanges();
                }
            }

        }
    }
}