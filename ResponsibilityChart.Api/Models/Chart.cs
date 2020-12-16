using System;
using System.Collections.Generic;
using ResponsibilityChart.Api.Enums;

namespace ResponsibilityChart.Api.Models
{
  public class Chart
  {
    // Properties
    public int Id { get; set; }
    public DateTime WeekStart { get; set; }
    public string Goal { get; set; }
    public PerformanceGrade Performance { get; set; }

    // Navigation Properties
    public Child AssignedChild { get; set; }
    public IList<Responsibility> AssignedResponsibilities { get; set; }
    public IList<CompletedResponsibility> CompletedResponsibilities { get; set; }
  }
}