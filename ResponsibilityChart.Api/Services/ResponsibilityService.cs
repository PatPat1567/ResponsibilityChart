using System.Linq;
using System.Collections.Generic;
using ResponsibilityChart.Api.Enums;
using ResponsibilityChart.Api.Models;
using ResponsibilityChart.Api.Interfaces;

namespace ResponsibilityChart.Api.Services
{
    public class ResponsibilityService : IResponsibilityService
    {
        public List<Responsibility> Responsibilities { get; }
        public int nextId { get; set; } = 0;
        public ResponsibilityService()
        {
            Responsibilities = new List<Responsibility>()
            {
                new Responsibility() { Id = 1, Name = "Pick Up Toys", ImageLink = "", RecommendedAgeGroups = new List<AgeGroup>() { AgeGroup.BelowTwo, AgeGroup.ThreeToFour }},
                new Responsibility() { Id = 2, Name = "Complete School Work", ImageLink = "", RecommendedAgeGroups = new List<AgeGroup>() { AgeGroup.FiveToEight, AgeGroup.EightToTwelve }},
            };
            nextId = Responsibilities.Max(x => x.Id) + 1;
        }

        public List<Responsibility> Get()
        {
            return Responsibilities;
        }

#nullable enable
        public Responsibility? Get(int id)
#nullable disable
        {
            return Responsibilities.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Responsibility responsibility)
        {
            responsibility.Id = nextId++;
            Responsibilities.Add(responsibility);
        }

        public void Update(Responsibility responsibility)
        {
            var index = Responsibilities.FindIndex(x => x.Id == responsibility.Id);
            if (index == -1)
                return;
            
            Responsibilities[index] = responsibility;
        }

        public void Delete(int id)
        {
            var responsibility = Get(id);
            if (responsibility is null)
                return;
            
            Responsibilities.Remove(responsibility);
        }
    }
}