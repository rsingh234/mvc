using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music_Store.Models;

namespace Music_Store.Controllers
{
    public class StroreController : Controller
    {
        MusicStoreContext context = new MusicStoreContext();
        // GET: Strore
        public ActionResult Index()
        {
            var genres = context.AllGenres.ToList();
            ViewBag.GeneresList = new SelectList(genres, "GenreId", "GenreName");
            return View(genres);

            
        }

        public ActionResult Browse(string genre)
        {
            //var genreModel = new Genre { GenreName = genre };
            //return View(genreModel);
            var genreModel = context.AllGenres.Include("Albums").Where(g =>
                g.GenreName == genre).Single();
          
            return View(genreModel);

        }

        [HttpPost]
        public ActionResult Browse(int genre)
        {
            //var genreModel = new Genre { GenreName = genre };
            //return View(genreModel);
            var genreModel = context.AllGenres.Include("Albums").Where(g =>
                g.GenreId == genre).Single();

            return View(genreModel);

        }

        //public string Details(int id)
        //{
        //    string message = "Store.Details(), ID = " + id;
        //    return message;
        //}
        public ActionResult Details(string id)
        {
            //var album = (from s in context.AllAlbums
            //             where s.GenreId == id
            //             //s.Contains("Tutorials")
            //             select s).FirstOrDefault()  ;
            var album = context.AllAlbums.Find(id);
                                   

            return View(album);

            //var album = new Album { Title = "Album " + id };
            //return View(album);
        }



    }
}