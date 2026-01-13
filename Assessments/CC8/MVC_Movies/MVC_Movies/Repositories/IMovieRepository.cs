using MVC_Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Movies.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Insert(Movie entity);
        void Update(Movie entity);
        void Delete(int id);

        IEnumerable<Movie> GetByYear(int year);
        IEnumerable<Movie> GetByDirector(string directorName);

        void Save();
    }

}
