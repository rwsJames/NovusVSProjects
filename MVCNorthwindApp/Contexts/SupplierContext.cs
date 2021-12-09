using MVCNorthwindApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCNorthwindApp.Contexts
{
    public class SupplierContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
    }
}