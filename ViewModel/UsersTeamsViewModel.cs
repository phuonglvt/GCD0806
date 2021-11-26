using GCD0806.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCD0806.ViewModel
{
    public class UsersTeamsViewModel
    {
        public int TeamId { get; set; }
        public List<Team> Teams { get; set; }
        public string UserId { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}