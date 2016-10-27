using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestApp.Models
{
    public class PageContext:DbContext
    {
        public DbSet<Page> Pages { get; set; }
    }
}