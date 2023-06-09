using Microsoft.EntityFrameworkCore;

namespace ProjectName.Models
{
  public class ParksLookUpAPIContext : DbContext
  {
    public DbSet<ClassName> ClassName { get; set; }
    public DbSet<ClassName2> ClassName2 { get; set; }

    public ProjectNameContext(DbContextOptions options) : base(options) { }
  }
}