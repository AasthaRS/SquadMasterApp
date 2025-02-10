using SquadMaster.TeamGenerationLibrary.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.Models.Group
{
    public interface IGroup
    {
        string ID { get; }

        string Name { get; set; }

        IMember Captain { get; set; }

        List<IMember> Members { get; set; }
    }
}
