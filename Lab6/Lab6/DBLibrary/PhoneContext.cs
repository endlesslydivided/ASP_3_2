using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public class PhoneContext : DbContext
    {
        public PhoneContext() : base("Server=.;Database=LAB4ASP;Trusted_Connection=True;Integrated Security=True")
        { }

        public DbSet<Phone> Phones { get; set; }
    }
}
