using System;

namespace ResponsibilityChart.Api.Models
{
  public class CompletedResponsibility
  {
    // Properties
    public int Id { get; set; }
    public DayOfWeek AssignedDay { get; set; }
    public bool Completed { get; set; }

    // Navigation Properties
    public Responsibility Responsibility { get; set; }

  }
}