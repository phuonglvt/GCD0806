using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCD0806.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Index("UniqueName",1,IsUnique = true)]
        public string Name { get; set; }
    }
}