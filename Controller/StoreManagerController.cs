using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music_Store.Models;
using System.Data;
using System.Data.Entity;

namespace Music_Store.Controllers
{
    public class StoreManagerController : Controller
    {
        MusicStoreContext context = new Models.MusicStoreContext();
        // GET: StoreManager
        public ActionResult Index()
        {
            

            return View(context.AllAlbums.Include("Artist").Include("Genre").ToList());
        }
        public ActionResult CreateNewAlbum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewAlbum(Music_Store.Models.Album a)
        {
            context.AllAlbums.Add(a);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditAlbum(string title)
        {
            Music_Store.Models.MusicStoreContext context = new
            Models.MusicStoreContext();
            var albumtoedit =
            context.AllAlbums.Include("Artist").
            Include("Genre").Where(a => a.Title == title).SingleOrDefault();
            return View(albumtoedit);
        }

        [HttpPost]
        public ActionResult EditAlbum(Music_Store.Models.Album a)
        {
            Music_Store.Models.MusicStoreContext context = new
            Models.MusicStoreContext();
            context.Entry(a).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAlbum(string title)
        {
            Music_Store.Models.MusicStoreContext context = new
            Models.MusicStoreContext();

            var albumtodelete = context.AllAlbums.Where(a => a.Title
                == title).SingleOrDefault();
            context.AllAlbums.Remove(albumtodelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: StoreManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreManager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
