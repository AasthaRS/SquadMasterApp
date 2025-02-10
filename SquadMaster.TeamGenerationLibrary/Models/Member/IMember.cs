using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.Models.Member
{
    public interface IMember
    {
        string ID { get; }

        string Name { get; set; }

        DateTime Dob { get; set; }

        Gender Gender { get; set; }

        string[] Mobile { get; set; }

        Game PreferredGames { get; set; }

        Department Department { get; set; }

        int Age { get; }
    }
}
