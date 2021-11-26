using GCD0806.Models;
using GCD0806.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCD0806.Controllers
{
    [Authorize(Roles = Role.Manager)]
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;
        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Category
        public ActionResult Index()
        {
            var cate = _context.Categories.ToList();
            return View(cate);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var newCate = new Category()
            {
                Description = model.Description
            };

            _context.Categories.Add(newCate);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cate = _context.Categories.SingleOrDefault(c => c.ID == id);
            if (cate == null)
            {
                return HttpNotFound();
            }
            _context.Categories.Remove(cate);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cate = _context.Categories.SingleOrDefault(c => c.ID == id);
            if (cate == null)
            {
                return HttpNotFound();
            }
            return View(cate);
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var cateInDb = _context.Categories.SingleOrDefault(c => c.ID == model.ID);
            if(cateInDb == null)
            {
                return HttpNotFound();
            }
            
            cateInDb.Description = model.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}