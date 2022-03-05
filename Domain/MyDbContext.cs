using Login.Demo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Demo.Domain
{
    public class MyDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public MyDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
