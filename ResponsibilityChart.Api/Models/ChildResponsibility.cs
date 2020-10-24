using System;

namespace ResponsibilityChart.Api.Models
{
  public class ChildResponsibility
  {
    public int Id { get; set; }
    public DateTime WeekId { get; set; }
    public Responsibility Responsibility { get; set; }
    public bool IsComplete { get; set; }
    public DayOfWeek WeekDay { get; set; }
  }
    
}