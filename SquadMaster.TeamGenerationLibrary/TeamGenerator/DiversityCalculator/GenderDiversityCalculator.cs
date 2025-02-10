﻿using SquadMaster.TeamGenerationLibrary.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.TeamGenerator.DiversityCalculator
{
    /// <summary>
    /// Diversify the Members based on their Gender
    /// </summary>
    internal class GenderDiversityCalculator : IDiversityCalculator
    {
        /// <summary>
        /// Type of calculator
        /// </summary>
        public DiversityType Type { get => DiversityType.Gender; }

        /// <summary>
        /// Priority of calculator
        /// </summary>
        public int Priority { get; }

        /// <summary>
        /// Initialize calculator with pre-defined priority
        /// </summary>
        public GenderDiversityCalculator()
        {
            Priority = 1;
        }

        /// <summary>
        /// Initialize calculator with user defined priority
        /// </summary>
        /// <param name="priority"></param>
        public GenderDiversityCalculator(int priority)
        {
            if (priority < 1)
            {
                priority = 1;
            }
            Priority = priority;
        }

        /// <summary>
        /// Get the score (Gini Coefficient) of Gender of the members
        /// </summary>
        /// <param name="members"></param>
        /// <returns>Return Gini Coefficient of genders</returns>
        public double GetScore(List<IMember> members)
        {
            // If there are no members in the team, return 0.
            if (members.Count == 0)
            {
                return 0;
            }

            try
            {
                // Get number of members in each gender group
                List<int> genderCounts = members.GroupBy(m => m.Gender)
                                          .Select(g => g.Count())
                                          .ToList();

                // Sum of the square of proportion of members belonging to each gender group within the entire team
                double sumOfSquares = 0;

                // Total number of members in the current team structure
                double totalMembers = members.Count;

                // Traverse over number of members in each gender group
                foreach (int count in genderCounts)
                {
                    // Calculating the proportion of members in each gender group within the entire team
                    double proportion = (double)count / totalMembers;

                    // Calculating the square of proportion
                    sumOfSquares += proportion * proportion;
                }

                // Calculating Gini Coefficient
                double giniCoefficient = 1 - sumOfSquares;
                return giniCoefficient;
            }
            catch (Exception ex) when (ex is ArgumentNullException)
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
