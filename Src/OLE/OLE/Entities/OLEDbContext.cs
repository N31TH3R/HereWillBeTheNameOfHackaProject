using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace OLE.Entities
{
    public class OLEDbContext : DbContext
    {
        public OLEDbContext(DbContextOptions<OLEDbContext> options) : base(options)
        {
        }

        public DbSet<Placemark> Placemark { get; set; }
        public DbSet<Event> Event { get; set; }
        
    }
}
