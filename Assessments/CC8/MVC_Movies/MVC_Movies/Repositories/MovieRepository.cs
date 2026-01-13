using MVC_Movies.Models;
using MVC_Movies.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Movies.Repositories
{
    public class MovieRepository : IMovieRepository, IDisposable
    {
        private readonly MoviesDbContext _ctx;
        private bool _disposed;

        public MovieRepository() : this(new MoviesDbContext()) { }
        public MovieRepository(MoviesDbContext ctx) { _ctx = ctx; }

        public IEnumerable<Movie> GetAll()
            => _ctx.Movies.OrderBy(m => m.Moviename).ToList();

        public Movie GetById(int id)
            => _ctx.Movies.Find(id);

        public void Insert(Movie entity)
            => _ctx.Movies.Add(entity);

        public void Update(Movie entity)
            => _ctx.Entry(entity).State = EntityState.Modified;

        public void Delete(int id)
        {
            var m = _ctx.Movies.Find(id);
            if (m != null) _ctx.Movies.Remove(m);
        }

        public IEnumerable<Movie> GetByYear(int year)
            => _ctx.Movies
                   .Where(m => m.DateofRelease.Year == year)
                   .OrderBy(m => m.Moviename)
                   .ToList();

        public IEnumerable<Movie> GetByDirector(string directorName)
        {
            if (string.IsNullOrWhiteSpace(directorName)) return Enumerable.Empty<Movie>();
            directorName = directorName.Trim();
            return _ctx.Movies
                       .Where(m => m.DirectorName == directorName) // exact match
                       .OrderBy(m => m.DateofRelease)
                       .ToList();
        }

        public void Save() => _ctx.SaveChanges();

        public void Dispose()
        {
            if (!_disposed)
            {
                _ctx.Dispose();
                _disposed = true;
            }
        }
    }
}
