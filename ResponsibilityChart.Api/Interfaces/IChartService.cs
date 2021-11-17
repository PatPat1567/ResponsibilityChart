using ResponsibilityChart.Api.Models;

namespace ResponsibilityChart.Api.Interfaces
{
    public interface IChartService
    {
        List<Chart> Get(string q, int size, int offset, string sortBy);
        Chart Get(int id);
        void Create(Chart chart);
        void Update(Chart chart);
        void Delete(int id);
    }
    
}