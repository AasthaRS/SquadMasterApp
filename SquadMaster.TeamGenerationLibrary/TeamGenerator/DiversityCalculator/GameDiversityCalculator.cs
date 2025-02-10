using SquadMaster.TeamGenerationLibrary.Models.Member;
using SquadMaster.TeamGenerationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.TeamGenerator.DiversityCalculator
{
    /// <summary>
    /// Diversify the Members based on their Preferred Games
    /// </summary>
    internal class GameDiversityCalculator : IDiversityCalculator
    {
        /// <summary>
        /// Type of calculator
        /// </summary>
        public DiversityType Type { get => DiversityType.Game; }

        /// <summary>
        /// Priority of calculator
        /// </summary>
        public int Priority { get; }

        /// <summary>
        /// Initialize calculator with pre-defined priority
        /// </summary>
        public GameDiversityCalculator()
        {
            Priority = 1;
        }

        /// <summary>
        /// Initialize calculator with user defined priority
        /// </summary>
        /// <param name="priority"></param>
        public GameDiversityCalculator(int priority)
        {
            if (priority < 1)
            {
                priority = 1;
            }
            Priority = priority;
        }

        /// <summary>
        /// Get all unique game values played by team members
        /// </summary>
        /// <param name="members"></param>
        /// <returns>Return total games team can play</returns>
        public double GetScore(List<IMember> members)
        {
            // If there are no members in the team, return 0.
            if (members.Count == 0)
            {
                return 0;
            }

            try
            {
                // Get all games played by individual members
                IEnumerable<Game> allGames = members.SelectMany(m => m.PreferredGames.ToString().Split(',').Select(g => (Game)Enum.Parse(typeof(Game), g.Trim())));

                // Get total number of unique games played by team members
                int uniqueGames = allGames.Distinct().Count();
                return uniqueGames;
            }
            catch (Exception ex) when (ex is ArgumentNullException ||
                                       ex is ArgumentException ||
                                       ex is OverflowException ||
                                       ex is InvalidOperationException)
            {
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
