using SquadMaster.TeamGenerationLibrary.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.TeamGenerator.DiversityCalculator
{
    internal class NullDiversityCalculator : IDiversityCalculator
    {
        /// <summary>
        /// Type of calculator -> Undefined
        /// </summary>
        public DiversityType Type { get => DiversityType.Undefined; }

        /// <summary>
        /// Priority of calculator -> Not considerable
        /// </summary>
        public int Priority { get => -1; }

        /// <summary>
        /// Zero diversity score
        /// </summary>
        /// <param name="members"></param>
        /// <returns>Return total games team can play</returns>
        public double GetScore(List<IMember> members)
        {
            return 0;
        }
    }
}
