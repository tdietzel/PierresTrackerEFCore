using Microsoft.EntityFrameworkCore;

namespace PierresTracker.Models
{
  public class PierresTrackerContext : DbContext
  {
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Order> Orders { get; set; }

    public PierresTrackerContext(DbContextOptions options) : base(options) { }
  }
}