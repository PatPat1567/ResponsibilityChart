using System;
using System.Collections.Generic;
using ResponsibilityChart.Blazor.Enums;

namespace ResponsibilityChart.Blazor.Models
{
  public class Chart 
  {
    public int Id { get; set; }
    public DateTime WeekStart { get; set; }
    public DateTime WeekEnd => WeekStart.AddDays(6);
    public Child AssignedChild { get; set; }
    public IList<Responsibility> AssignedResponsibilities { get; set; }
    public IList<CompletedResponsibility> CompletedResponsibilities { get; set; }
    public string Goal { get; set; }
    public PerformanceGrade? Performance { get; set; }

    public Chart()
    {
        AssignedResponsibilities = new List<Responsibility>();
        CompletedResponsibilities = new List<CompletedResponsibility>();
    }
  }
}