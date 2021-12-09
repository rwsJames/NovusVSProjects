using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProductsApp.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("name")]
        [StringLength(40)]
        public string Name { get; set; }

        [DisplayName("email")]
        [StringLength(50)]
        [Required(ErrorMessage = "an email must be provided")]
        public string Email { get; set; }

        [DisplayName("content")]
        [StringLength(500)]
        public string Content { get; set; }

        [DisplayName("rating")]
        [Required(ErrorMessage = "a rating between 1 and 5 is required")]
        [Range(1, 5, ErrorMessage = "rating must be a whole nuber between 1 and 5")]
        public int Rating { get; set; }
    }
}