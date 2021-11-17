using ResponsibilityChart.Api.Interfaces;
using ResponsibilityChart.Api.Models;

namespace ResponsibilityChart.Api.Services
{
    public class ChartService : IChartService
    {
        public List<Chart> Charts { get; }
        public int nextId { get; set; } = 0;

        public ChartService()
        {
            Charts = new List<Chart>()
            {
                new Chart() { Id = 1, WeekStart = new DateTime(2012, 11,14), Goal = "70% coverage", Performance = Enums.PerformanceGrade.Excellent}
            };
        }

        public List<Chart> Get(string q, int size, int offset, string sortBy)
        {
            //Need to add pagination, sorting & searching
            return Charts;
        }

        public Chart Get(int id)
        {
            return Charts.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Chart chart)
        {
            chart.Id = nextId++;
            Charts.Add(chart);
        }

        public void Update(Chart chart)
        {
            var index = Charts.FindIndex(x => x.Id == chart.Id);
            if (index == -1)
                return;

            Charts[index] = chart;
        }

        public void Delete(int id)
        {
            var existingChart = Get(id);
            if (existingChart is null)
                return;

            Charts.Remove(existingChart);   
        }
    }

}