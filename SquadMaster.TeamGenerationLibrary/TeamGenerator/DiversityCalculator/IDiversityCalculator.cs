using SquadMaster.TeamGenerationLibrary.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.TeamGenerator.DiversityCalculator
{
    /// <summary>
    /// Diversify the Members based on their Type
    /// </summary>
    internal interface IDiversityCalculator
    {
        /// <summary>
        /// Type of calculator
        /// </summary>
        DiversityType Type { get; }

        /// <summary>
        /// Priority of calculator
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// Get the diversification score of the team members
        /// </summary>
        /// <param name="members"></param>
        /// <returns>Return total games team can play</returns>
        double GetScore(List<IMember> members);
    }
}
