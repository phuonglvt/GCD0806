using GCD0806.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCD0806.ViewModel
{
    public class Todo_CategoryViewModel
    {
        public Todo Todo { get; set; }
        public IEnumerator<Category> Category { get; set; }

    }
}