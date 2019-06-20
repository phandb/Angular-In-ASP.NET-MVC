using AngularWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Constructor to set up connection string
        public ApplicationDbContext() : base("AppConnectionString") { }

        public static ApplicationDbContext Create() => new ApplicationDbContext();

        //add data set for model to fetch, update, or delete record from table
        public DbSet<PlayerRecord> PlayerRecords { get; set; }
    }
}