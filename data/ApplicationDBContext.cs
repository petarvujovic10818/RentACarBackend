using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rentacar.models;

namespace rentacar.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Car> Cars {get; set;}
        public DbSet<Feedback> Feedbacks {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<User> Users {get; set;}
    }
}