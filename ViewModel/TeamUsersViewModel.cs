using GCD0806.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCD0806.ViewModel
{
    public class TeamUsersViewModel
    {
        public string UserId { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public int TeamId { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}