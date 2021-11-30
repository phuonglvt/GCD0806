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
        
        // GET: Team
        [HttpGet]
        public ActionResult Index()
        {
            var teams = _context.Teams
        .OrderBy(m => m.Id)
        .ToList();
            return View(teams);
        }

        [HttpGet]
        public ActionResult ShowUsers(int id)
        {
            var users = _context.UserTeams
                .Where(i => i.TeamId == id)
                .Select(i => i.User)
                .ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult AssignUser()
        {
            var role = _context.Roles
              .SingleOrDefault(r => r.Name.Equals(Role.User));
            var users = _context.Users
              .Where(m => m.Roles.Any(r => r.RoleId.Equals(role.Id)))
              .ToList();
            var viewModel = new TeamUsersViewModel
            {
                Teams = _context.Teams.ToList(),
                Users = users
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AssignUser(TeamUsersViewModel viewModel)
        {
            var model = new UserTeam
            {
                TeamId = viewModel.TeamId,
                UserId = viewModel.UserId
            };

            try
            {
                _context.UserTeams.Add(model);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                ModelState.AddModelError("duplicate", "User already existed in Team");
                var role = _context.Roles
                .SingleOrDefault(r => r.Name.Equals(Role.User));
                var users = _context.Users
                  .Where(m => m.Roles.Any(r => r.RoleId.Equals(role.Id)))
                  .ToList();
                var newViewModel = new TeamUsersViewModel
                {
                    Teams = _context.Teams.ToList(),
                    Users = users
                };
                return View(newViewModel);
            }

            return RedirectToAction("Index");
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
            try
            {
                _context.Teams.Add(newTeam);
                _context.SaveChanges();
            }
            catch(System.Exception)
            {
                ModelState.AddModelError("Duplicate", "Team name already existed");
            }
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
            if (viewModel is null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            var userTeam = _context.UserTeams
                .SingleOrDefault(t => t.TeamId == viewModel.TeamId && t.UserId == viewModel.UserId);

            if (userTeam == null)
            {
                return HttpNotFound();
            }

            _context.UserTeams.Remove(userTeam);
            _context.SaveChanges();
            return RedirectToAction("Index", "Team");
        }
    }
}