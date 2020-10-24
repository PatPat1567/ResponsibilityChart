using System.Collections.Generic;

namespace ResponsibilityChart.Api.Models
{
  public class Child
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public IEnumerable<ChildResponsibility> ChildResponsibilities { get; set; }
  }
}