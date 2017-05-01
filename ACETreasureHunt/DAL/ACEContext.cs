using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ACETreasureHunt.Models;


namespace ACETreasureHunt.DAL
{
    public class ACEContext : DbContext
    {
        public ACEContext()
            : base("name=ACEContext")
        {
            
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<PitStop> PitStops { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           //modelBuilder.Configurations.Add();
        }

        //public System.Data.Entity.DbSet<ACETreasureHunt.Models.Team> Teams { get; set; }
    }
}
