using ResponsibilityChart.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ResponsibilityChart.Data.Configurations
{
  public class ResponsibilityConfiguration : IEntityTypeConfiguration<Responsibility>
  {
    public void Configure(EntityTypeBuilder<Responsibility> builder)
    {
      builder.HasKey(r => r.Id);
      builder.Property(r => r.Name)
        .IsRequired();
    }
  }
}