using GCD0806.Models;
using GCD0806.Utils;
using GCD0806.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCD0806.Controllers
{
    [Authorize(Roles =Role.Manager)]
    public class TeamController : Controller
    {
        private ApplicationDbContext _context;
        public TeamController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult ShowTeam()
        {
            var teams = _context.Teams.ToList();
            return View(teams);
        }
        // GET: Team
        [HttpGet]
        public ActionResult Index()
        {
            List<TeamUsersViewModel> viewModel = _context.UserTeams
                .GroupBy(i => i.Team)
                .Select(res => new TeamUsersViewModel
                {
                    Team = res.Key,
                    User = res.Select(u => u.User).ToList()
                })
                .ToList();
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View(team);
            }
            var newTeam = new Team()
            {
                Name = team.Name
            };
            _context.Teams.Add(newTeam);
            _context.SaveChanges();
            return RedirectToAction("Index", "Team");
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            var role = _context.Roles.SingleOrDefault(m => m.Name == Role.User);
            var viewModel = new UsersTeamsViewModel()
            {
                Teams = _context.Teams.ToList(),
                Users = _context.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddUser(UsersTeamsViewModel viewModel)
        {
            var model = new UserTeam
            {
                TeamId = viewModel.TeamId,
                UserId = viewModel.UserId
            };
            _context.UserTeams.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Team");

        }
        [HttpGet]
        public ActionResult RemoveUser()
        {
            var users = _context.UserTeams
                .Select(t => t.User)
                .Distinct()
                .ToList();
            var teams = _context.UserTeams
                .Select(t => t.Team)
                .Distinct()
                .ToList();
            var viewModel = new UsersTeamsViewModel
            {
                Teams = teams,
                Users = users
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult RemoveUser(UsersTeamsViewModel viewModel)
        {
            var userTeam = _context.UserTeams
                .SingleOrDefault(t => t.TeamId == viewModel.TeamId && t.UserId == viewModel.UserId);

            if(userTeam == null)
            {
                return HttpNotFound();
            }

            _context.UserTeams.Remove(userTeam);
            _context.SaveChanges();
            return RedirectToAction("Index", "Team");
        }
    }
}