using GCD0806.Models;
using GCD0806.ViewModel;
using Microsoft.AspNet.Identity;
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
            var userId = User.Identity.GetUserId();
            var todos = _context.Todos
                .Include("Category") //Nếu không có, CateID Null, Không hiển thị đc, phải include obj để hiển thị Des của CateID
                .Where(t => t.UserId == userId)
                .ToList();
            return View(todos);
        }
        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();
            var todo = _context.Todos
                .Include("Category")
                .SingleOrDefault(t => t.Id == id && t.UserId == userId);
            if(todo == null)
            {
                return HttpNotFound();
            }    
            return View(todo);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new TodoCategoryViewModel()
            {
                Category = categories
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(TodoCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TodoCategoryViewModel()
                {
                    Todo = model.Todo,
                    Category = _context.Categories.ToList()
                };
                return View(viewModel);
            }

            var userId = User.Identity.GetUserId();
            var newTodo = new Todo()
            {
                Description = model.Todo.Description,
                DueDate = model.Todo.DueDate,
                CategoryId = model.Todo.CategoryId,
                UserId = userId
            };

            _context.Todos.Add(newTodo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var todo = _context.Todos.SingleOrDefault(t => t.Id == id && t.UserId == userId);
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
            var userId = User.Identity.GetUserId();
            var todo = _context.Todos.SingleOrDefault(t => t.Id == id && t.UserId == userId);
            if (todo == null)
            {
                return HttpNotFound();
            }
            var viewModel = new TodoCategoryViewModel()
            {
                Todo = todo,
                Category = _context.Categories.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(TodoCategoryViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                var viewModel = new TodoCategoryViewModel()
                {
                    Todo = model.Todo,
                    Category = _context.Categories.ToList()
                };
                return View(viewModel);
            }

            var userId = User.Identity.GetUserId();

            var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == model.Todo.Id && t.UserId == userId);
            if (todoInDb == null)
            {
                return HttpNotFound();
            }

            todoInDb.Description = model.Todo.Description;
            todoInDb.DueDate = model.Todo.DueDate;
            todoInDb.CategoryId = model.Todo.CategoryId;
            _context.SaveChanges();

            return RedirectToAction("Index","Todo");
        }
    }
}