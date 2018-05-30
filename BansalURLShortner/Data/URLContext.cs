using BansalURLShortner.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BansalURLShortner.Data
{
    public class URLContext : DbContext
    {
        public URLContext()
           : base("Name=URLContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<URLContext, Migrations.Configuration>());
        }

        public DbSet<URL> URLs { get; set; }
        public DbSet<URLClick> URLClicks { get; set; }
    }
}