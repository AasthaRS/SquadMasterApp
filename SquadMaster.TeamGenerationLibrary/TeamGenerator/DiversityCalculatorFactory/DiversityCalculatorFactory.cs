using SquadMaster.TeamGenerationLibrary.TeamGenerator.DiversityCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.TeamGenerator.DiversityCalculatorFactory
{
    internal class DiversityCalculatorFactory
    {
        public static IDiversityCalculator CreateCalculator(DiversityType type, int priority = 1)
        {
            return type switch
            {
                DiversityType.Age => new AgeDiversityCalculator(priority: priority),
                DiversityType.Gender => new GenderDiversityCalculator(priority: priority),
                DiversityType.Department => new DepartmentDiversityCalculator(priority: priority),
                DiversityType.Game => new GameDiversityCalculator(priority: priority),
                _ => new NullDiversityCalculator()
            };
        }
    }
}
