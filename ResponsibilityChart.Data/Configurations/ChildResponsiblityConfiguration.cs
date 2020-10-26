using ResponsibilityChart.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ResponsibilityChart.Data.Configurations
{
  public class ChildResponsibilityConfiguration : IEntityTypeConfiguration<ChildResponsibility>
  {
    public void Configure(EntityTypeBuilder<ChildResponsibility> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(c => c.IsComplete)
        .IsRequired();
      builder.Property(c => c.WeekDay)
        .IsRequired();
      builder.Property(c => c.WeekId)
        .IsRequired();
    }
  }
}