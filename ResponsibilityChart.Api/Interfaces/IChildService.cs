using ResponsibilityChart.Api.Models;

namespace ResponsibilityChart.Api.Interfaces
{
    public interface IChildService
    {
        List<Child> Get();
        Child Get(Guid id);
        void Add(Child child);
        void Update(Child child);
        void Delete(Guid id);
    }
    
}