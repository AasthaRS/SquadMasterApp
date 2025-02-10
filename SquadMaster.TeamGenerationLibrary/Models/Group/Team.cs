using SquadMaster.TeamGenerationLibrary.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.Models.Group
{
    public class Team : IGroup
    {
        public Team() : this(Resources.DefaultTeamName)
        {
        }

        public Team(string teamName)
        {
            // Generate ID while generating teams from the members
            ID = Guid.NewGuid().ToString();

            Name = teamName;

            Captain = new NullMember();

            Members = new List<IMember>();
        }

        public string ID { get; }
        public string Name { get; set; }
        public IMember Captain { get; set; }

        public List<IMember> Members { get; set; }

        public override string ToString()
        {
            StringBuilder team = new();
            team.AppendLine($"ID: {ID}");
            team.AppendLine($"Name: {Name}");
            team.AppendLine($"Member count: {Members.Count}");
            team.AppendLine($"Caption:");
            team.AppendLine(Captain.ToString());
            team.AppendLine($"Members:");
            foreach (IMember member in Members)
            {
                team.AppendLine(member.ToString());
                team.AppendLine();
            }
            return team.ToString();
        }
    }
}
