using System.Collections.Generic;
using ResponsibilityChart.Api.Models;

namespace ResponsibilityChart.Api.Interfaces
{
    public interface IResponsibilityService
    {
        List<Responsibility> Get();
        Responsibility Get(int id);
        void Add(Responsibility responsibility);
        void Update(Responsibility responsibility);
        void Delete(int id);
    }
}