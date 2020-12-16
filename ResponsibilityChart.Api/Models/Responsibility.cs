using System.Collections.Generic;
using ResponsibilityChart.Api.Enums;

namespace ResponsibilityChart.Api.Models
{
  public class Responsibility
  {
    // Properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageLink { get; set; }
    public IList<AgeGroup> RecommendedAgeGroups { get; set; }
  }
}