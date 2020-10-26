using ResponsibilityChart.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ResponsibilityChart.Data.Configurations
{
  public class ChildConfiguration : IEntityTypeConfiguration<Child>
  {
    public void Configure(EntityTypeBuilder<Child> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(c => c.Name)
        .IsRequired();
    }
  }
}