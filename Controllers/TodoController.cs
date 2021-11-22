using GCD0806.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCD0806.Controllers
{
    public class TodoController : Controller
    {
        private ApplicationDbContext _context;
        public TodoController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Todo
        public ActionResult Index()
        {
            var todos = _context.Todos
                .Include("Category") //Nếu không có, CateID Null, Không hiển thị đc, phải include obj để hiển thị Des của CateID
                .ToList();
            return View(todos);
        }
        public ActionResult Details(int id)
        {
            var todo = _context.Todos
                .Include("Category")
                .SingleOrDefault(t => t.Id == id);
            if(todo == null)
            {
                return HttpNotFound();
            }    
            return View(todo);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Todo model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var newTodo = new Todo()
            {
                Description = model.Description,
                DueDate = model.DueDate
            };

            _context.Todos.Add(newTodo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var todo = _context.Todos.SingleOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var todo = _context.Todos.SingleOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }
        [HttpPost]
        public ActionResult Edit(Todo model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == model.Id);
            if (todoInDb == null)
            {
                return HttpNotFound();
            }

            todoInDb.Description = model.Description;
            todoInDb.DueDate = model.DueDate;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}