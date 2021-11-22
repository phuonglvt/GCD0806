using GCD0806.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCD0806.ViewModel
{
    public class TodoCategoryViewModel
    {
        public Todo Todo { get; set; }
        public List<Category> Category { get; set; }

    }
}