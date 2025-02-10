using SquadMaster.TeamGenerationLibrary.Models.Group;
using SquadMaster.TeamGenerationLibrary.Models.Member;
using SquadMaster.TeamGenerationLibrary.TeamGenerator.DiversityCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.TeamGenerator
{
    internal class TeamGenerator : ITeamGenerator
    {
        // Diversity Calculators
        private List<IDiversityCalculator> _diversityCalculators;

        /// <summary>
        /// Initialize number of teams and diversity calculators
        /// </summary>
        /// <param name="teamCount"></param>
        /// <param name="diversityCalculators"></param>
        public TeamGenerator(List<IDiversityCalculator> diversityCalculators, int teamCount = 2)
        {
            if (teamCount < 2)
            {
                teamCount = 2;
            }
            Teams = new List<Team>();
            for (int i = 0; i < teamCount; i++)
            {
                Teams.Add(new Team { Name = $"Team {i + 1}" });
            }

            try
            {
                _diversityCalculators = diversityCalculators.Where(calculator => calculator.Priority > 0).ToList();
            }
            catch (Exception ex) when (ex is ArgumentNullException)
            {
                _diversityCalculators = new List<IDiversityCalculator>();
            }
            catch (Exception)
            {
                _diversityCalculators = new List<IDiversityCalculator>();
            }
        }

        // Teams
        public List<Team> Teams { get; }

        /// <summary>
        /// Generate teams from the list of members given
        /// </summary>
        /// <param name="members"></param>
        /// <returns>List of Teams</returns>
        public List<Team> Generate(List<Member> members)
        {
            // Generate the teams only if the members count is greater than the team count
            if (Teams.Count > 1 &&
                members.Count > 0 &&
                members.Count >= Teams.Count)
            {
                try
                {
                    // Maximum team size
                    int maxTeamSize = (int)Math.Ceiling((double)members.Count / Teams.Count);

                    // Shuffle the members list randomly
                    List<Member> shuffledMembers = members.OrderBy(member => Guid.NewGuid()).ToList();

                    // Assign a team to the member one by one
                    foreach (Member member in shuffledMembers)
                    {
                        // Find the most suitable team for the member
                        Team targetTeam = InternalFindBestTeam(maxTeamSize);

                        if (targetTeam != null)
                        {
                            targetTeam.Members.Add(member);
                        }
                        else
                        {
                            // If no suitable team is found, assign to the least populated team
                            targetTeam = Teams.OrderBy(t => t.Members.Count).First();
                            targetTeam.Members.Add(member);
                        }
                    }

                    // Assigning Captains to the teams
                    foreach (Team team in Teams)
                    {
                        team.Captain = InternalGetCaptain(team.Members);
                    }
                }
                catch (Exception ex) when (ex is ArgumentNullException ||
                                           ex is InvalidOperationException)
                {
                    foreach (Team team in Teams)
                    {
                        team.Members.Clear();
                        team.Captain = new NullMember();
                    }
                    return Teams;
                }
                catch (Exception)
                {
                    foreach (Team team in Teams)
                    {
                        team.Members.Clear();
                        team.Captain = new NullMember();
                    }
                    return Teams;
                }
            }
            return Teams;
        }

        /// <summary>
        /// Finding the best team
        /// </summary>
        /// <param name="maxTeamSize"></param>
        /// <returns></returns>
        protected Team InternalFindBestTeam(int maxTeamSize)
        {
            IOrderedEnumerable<Team> team = Teams.OrderBy(team => team.Members.Count);
            _diversityCalculators = _diversityCalculators
                .OrderBy(calculator => calculator.Priority)
                .ToList();
            foreach (IDiversityCalculator calculator in _diversityCalculators)
            {
                team = team.ThenByDescending(t => calculator.GetScore(t.Members));
            }
            return team.First(team => team.Members.Count < maxTeamSize);
        }

        /// <summary>
        /// Get the team captain
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        protected IMember InternalGetCaptain(List<IMember> members)
        {
            if (members.Count == 0) return new NullMember();

            // Sort members by age
            List<Member> sortedMembers = members.OfType<Member>().OrderBy(m => m.Age).ToList();

            // Find the index of the middle member(s) -> The median members
            int midIndex = sortedMembers.Count / 2;

            // If even number of members, select the older middle member
            return sortedMembers.Count % 2 == 0 ? sortedMembers[midIndex] : sortedMembers[midIndex + 1];
        }
    }
}
