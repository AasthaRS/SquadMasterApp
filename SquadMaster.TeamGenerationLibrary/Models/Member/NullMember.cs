using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.Models.Member
{
    public class NullMember : IMember
    {
        public string ID { get => String.Empty; }

        public string Name { get => String.Empty; set => value = String.Empty; }

        public DateTime Dob { get => DateTime.MinValue; set => value = DateTime.MinValue; }

        public Gender Gender { get => Gender.Unknown; set => value = Gender.Unknown; }

        public string[] Mobile { get => Array.Empty<String>(); set => value = Array.Empty<String>(); }

        public Game PreferredGames { get => Game.None; set => value = Game.None; }

        public Department Department { get => Department.Undefined; set => value = Department.Undefined; }

        public int Age { get => -1; }
    }
}
