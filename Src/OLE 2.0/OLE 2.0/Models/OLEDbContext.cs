using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLE
{
    public class OLEDbContext : DbContext
{
    public OLEDbContext(DbContextOptions<OLEDbContext> options) : base(options)
    {

    }

    public DbSet<Placemark> Placemark { get; set; }

    }
}
