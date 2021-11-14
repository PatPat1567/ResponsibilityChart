using System.Reflection.Metadata;
using ResponsibilityChart.Api.Enums;
using ResponsibilityChart.Api.Models;
using ResponsibilityChart.Api.Interfaces;

namespace ResponsibilityChart.Api.Services
{
    public class ChildService : IChildService
    {
        public List<Child> Children { get; }
        public ChildService()
        {
            Children = new List<Child>()
            {
                new Child() { Id = Guid.NewGuid(), Name = "Brooklyn", DateOfBrith = new DateTime(2016, 1, 28), Gender = Gender.Female },
                new Child() { Id = Guid.NewGuid(), Name = "Teagan", DateOfBrith = new DateTime(2018, 8, 10), Gender = Gender.Female },
                new Child() { Id = Guid.NewGuid(), Name = "Emersyn", DateOfBrith = new DateTime(2020, 10, 16), Gender = Gender.Female }
            };
            
        }

        public List<Child> Get()
        {
            return Children;
        }

#nullable enable
        public Child? Get(Guid id)
#nullable disable
        {
            return Children.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Child child)
        {
            child.Id = Guid.NewGuid();
            Children.Add(child);
        }

        public void Update(Child child)
        {
            var index = Children.FindIndex(x => x.Id == child.Id);
            if (index == -1)
                return;

            Children[index] = child;
        }

        public void Delete(Guid id)
        {
            var child = Get(id);
            if (child is null)
                return;
            
            Children.Remove(child);
        }
    }
    
}