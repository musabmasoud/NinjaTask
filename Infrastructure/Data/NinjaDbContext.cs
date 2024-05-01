using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class NinjaDbContext:DbContext
    {
        public NinjaDbContext(DbContextOptions<NinjaDbContext>dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<UserSegment> UserSegments { get; set; }

    }
}
