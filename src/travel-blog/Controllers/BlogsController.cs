﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using travel_blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace travel_blog.Controllers
{
    public class BlogsController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();


        public IActionResult Details(int id)
        {
            var thisEntry = db.Blogs
                .Include(locationId => locationId.LocationBlogs)
                .ThenInclude(loc => loc.Location)
                .Include(peepId => peepId.BlogPeoples)
                .ThenInclude(peep => peep.People)
                .FirstOrDefault(blogs => blogs.BlogId == id);

            return View(thisEntry);
        }

        public IActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "City");
            ViewBag.PeopleId = new SelectList(db.Peoples, "PeopleId", "Name");
            return View();
        }

        [HttpPost] 
        public IActionResult Create(Blog blog)
        {
            db.Blogs.Add(blog);
            db.SaveChanges();
            return RedirectToAction("NewEntryAdd", new { id = blog.BlogId });
        }

        public IActionResult NewEntryAddLocation(int id)
        {
           var thisEntry = db.Blogs.Firstor
            return View();
        }

    }
}
