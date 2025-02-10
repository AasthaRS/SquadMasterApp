using SquadMaster.TeamGenerationLibrary.Models.Group;
using SquadMaster.TeamGenerationLibrary.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.TeamGenerator
{
    // Team Generator Blueprint
    internal interface ITeamGenerator
    {
        /// <summary>
        /// Generate teams using list of members
        /// </summary>
        /// <param name="members"></param>
        /// <returns>Teams</returns>
        List<Team> Generate(List<Member> members);
    }
}
