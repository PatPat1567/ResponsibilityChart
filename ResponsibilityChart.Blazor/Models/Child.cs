using System;
using ResponsibilityChart.Blazor.Enums;

namespace ResponsibilityChart.Blazor.Models
{
  public class Child
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Gender? Gender { get; set; }

    public Child()
    {
      Id = Guid.NewGuid();
    }
  }
    
}