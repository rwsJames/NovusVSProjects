using MVCProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProductsApp.Context
{
    public class FeedbackContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}