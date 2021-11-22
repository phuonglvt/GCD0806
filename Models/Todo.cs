using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GCD0806.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [ForeignKey("Category")]
        //Tạo cột CategoryID
        public int CategoryId { get; set; }
        //Nối Todo vs Category (linking obj)
        public Category Category { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        
        
    }
}