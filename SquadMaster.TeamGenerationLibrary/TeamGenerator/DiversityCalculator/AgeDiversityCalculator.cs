using SquadMaster.TeamGenerationLibrary.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.TeamGenerator.DiversityCalculator
{
    /// <summary>
    /// Diversify the Members based on their age
    /// </summary>
    internal class AgeDiversityCalculator : IDiversityCalculator
    {
        /// <summary>
        /// Type of calculator
        /// </summary>
        public DiversityType Type { get => DiversityType.Age; }

        /// <summary>
        /// Priority of calculator
        /// </summary>
        public int Priority { get; }

        /// <summary>
        /// Initialize calculator with pre-defined priority
        /// </summary>
        public AgeDiversityCalculator()
        {
            Priority = 1;
        }

        /// <summary>
        /// Initialize calculator with user defined priority
        /// </summary>
        /// <param name="priority"></param>
        public AgeDiversityCalculator(int priority)
        {
            if (priority < 1)
            {
                priority = 1;
            }
            Priority = priority;
        }

        /// <summary>
        /// Get the score (standard deviation) of Ages of the members
        /// </summary>
        /// <param name="members"></param>
        /// <returns>Standard Deviation of ages</returns>
        public double GetScore(List<IMember> members)
        {
            // If there are no members in the team, return 0.
            if (members.Count == 0)
            {
                return 0;
            }

            try
            {
                List<Member> validMembers = members.OfType<Member>().ToList();

                // Average age
                double averageAge = validMembers.Average(member => member.Age);

                // Sum of squares of deviation ages from the average/mean age
                double sumOfDeviationSquares = validMembers.Sum(member => Math.Pow(member.Age - averageAge, 2));

                // Standard deviation of ages
                double standardDeviationAge = Math.Sqrt(sumOfDeviationSquares / members.Count);
                return standardDeviationAge;
            }
            catch (Exception ex) when (ex is ArgumentNullException ||
                                      ex is InvalidOperationException ||
                                      ex is OverflowException)
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
