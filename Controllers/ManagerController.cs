using GCD0806.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCD0806.Controllers
{
    public class ManagerController : Controller
    {
        private ApplicationDbContext _context;

        public ManagerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
    }
}