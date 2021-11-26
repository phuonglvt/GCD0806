﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCD0806.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public String Description { get; set; }
    }
}