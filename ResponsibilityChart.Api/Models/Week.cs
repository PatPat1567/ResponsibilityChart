using System;
using System.Collections.Generic;

namespace ResponsibilityChart.Api.Models
{
  public class Week
  {
    private const string WEEKSTARTDAY = "Sunday";
    public DateTime WeekStart => DetermineWeekStart(DateTime.Today);
    public IEnumerable<string> WeekDays => 
      Enum.GetNames(typeof(DayOfWeek));

    private DateTime DetermineWeekStart(DateTime Day)
    {
      if (Day.DayOfWeek.ToString() != WEEKSTARTDAY)
      {
        Day = DetermineWeekStart(Day.AddDays(-1));
      }
      return Day;
    }
  }
}