using System;
using ResponsibilityChart.Api.Enums;

namespace ResponsibilityChart.Api.Models
{
  public class Child
  {
    // Properties
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBrith { get; set; }
    public Gender Gender { get; set; }
  }
}