using Microsoft.EntityFrameworkCore;

namespace PierresTracker.Models
{
  public class PierresTrackerContext : DbContext
  {
    // change to Order?
    public DbSet<Order> Orders { get; set; }

    public PierresTrackerContext(DbContextOptions options) : base(options) { }
  }
}