using Lab4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Repository
{
    public class СontactDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=LAB4ASP;Trusted_Connection=True;Integrated Security=True");
            }
        }

        public СontactDBContext()
        {
        }

        public СontactDBContext(DbContextOptions<СontactDBContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }



    }
}