using GCD0806.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCD0806.ViewModel
{
    public class TeamUsersViewModel
    {
        public Team Team { get; set; }
        public List<ApplicationUser> User { get; set; }
    }
}