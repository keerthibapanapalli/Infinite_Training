using MVC_Movies.Models;
using MVC_Movies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _repo;

        public MoviesController() : this(new MovieRepository()) { }
        public MoviesController(IMovieRepository repo) { _repo = repo; }

        // GET: /Movies
        public ActionResult Index()
        {
            var movies = _repo.GetAll();
            return View(movies); // Views/Movies/Index.cshtml
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            return View(); // Views/Movies/Create.cshtml
        }

        // POST: /Movies/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid) return View(movie);
            _repo.Insert(movie);
            _repo.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var movie = _repo.GetById(id);
            if (movie == null) return RedirectToAction("Index"); 
            return View(movie); 
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid) return View(movie);
            _repo.Update(movie);
            _repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var movie = _repo.GetById(id);
            if (movie == null) return RedirectToAction("Index");
            return View(movie);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            _repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult ByYear(int year)
        {
            var movies = _repo.GetByYear(year);
            ViewBag.FilterTitle = $"Movies released in {year}";
            return View("Filter", movies); 
        }

        public ActionResult ByDirector(string directorName)
        {
            var movies = _repo.GetByDirector(directorName);
            ViewBag.FilterTitle = $"Movies by {directorName}";
            return View("Filter", movies); 
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _repo is System.IDisposable d) d.Dispose();
            base.Dispose(disposing);
        }
    }
}
