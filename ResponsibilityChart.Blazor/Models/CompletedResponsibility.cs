using System;

namespace ResponsibilityChart.Blazor.Models
{
  public class CompletedResponsibility
  {
    public int Id { get; set; }
    public Responsibility Responsibility { get; set; }
    public DayOfWeek AssignedDay { get; set; }
    public bool Completed { get; set; }

    public CompletedResponsibility()
    {
        
    }
  }

}