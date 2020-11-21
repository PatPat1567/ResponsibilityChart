using System.Collections.Generic;
using ResponsibilityChart.Blazor.Enums;

namespace ResponsibilityChart.Blazor.Models
{
  public class Responsibility
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageLink { get; set; }
    public IList<AgeGroup> RecommendedAgeGroups { get; set; }

    public Responsibility()
    {
      RecommendedAgeGroups = new List<AgeGroup>();
    }
  }
    
}