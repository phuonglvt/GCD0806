using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCD0806.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Descripition { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; internal set; }
    }
}