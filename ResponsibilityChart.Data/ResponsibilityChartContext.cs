using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ResponsibilityChart.Api.Models;
using ResponsibilityChart.Data.Configurations;

namespace ResponsibilityChart.Data
{
  public class ResponsibilityChartContext : DbContext
  {
    public DbSet<Child> Children { get; set; }
    public DbSet<Responsibility> Responsibilities { get; set; }

    public ResponsibilityChartContext(DbContextOptions<ResponsibilityChartContext> options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ResponsibilityChart;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ChildConfiguration());
      modelBuilder.ApplyConfiguration(new ResponsibilityConfiguration());
    }
  }
}