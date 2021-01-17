using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MuseumManagement.Models;

namespace MuseumManagement.Data
{
    public class MuseumManagementContext : DbContext
    {
        public MuseumManagementContext (DbContextOptions<MuseumManagementContext> options)
            : base(options)
        {
        }

        public DbSet<MuseumManagement.Models.Author> Author { get; set; }

        public DbSet<MuseumManagement.Models.City> City { get; set; }


        public DbSet<MuseumManagement.Models.Exhibition> Exhibition { get; set; }

        public DbSet<MuseumManagement.Models.Item> Item { get; set; }

        public DbSet<MuseumManagement.Models.ItemAuthor> ItemAuthor { get; set; }

        public DbSet<MuseumManagement.Models.Location> Location { get; set; }

        public DbSet<MuseumManagement.Models.Museum> Museum { get; set; }
    }
}
