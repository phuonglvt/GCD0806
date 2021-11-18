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
        // GET: Todo
        public ActionResult Index()
        {
            
            var todos = new List<Todo>()
            {
                new Todo()
                {
                    Id = 1,
                    Descripition = "Buy Drink",
                    DueDate =new DateTime(2021,11,20)
                },
                new Todo()
                {
                    Id = 2,
                    Descripition = "Buy Fresh",
                    DueDate =new DateTime(2020,01,15)
                },
                new Todo()
                {
                    Id = 3,
                    Descripition = "Buy Fish",
                    DueDate =new DateTime(2021,09,10)
                },
                new Todo()
                {
                    Id = 4,
                    Descripition = "Buy Meat",
                    DueDate =new DateTime(2021,10,10)
                },
            };
            return View(todos);
        }
    }
}