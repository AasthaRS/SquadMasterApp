using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.Models
{
    /// <summary>
    /// Represents different types of games a participant can play.
    /// Supports bitwise operations for multiple game selections.
    /// </summary>
    [Flags]
    public enum Game
    {
        /// <summary>
        /// No game selected.
        /// </summary>
        None = 0,

        /// <summary>
        /// Represents the sport of Tennis.
        /// </summary>
        Tennis = 1,

        /// <summary>
        /// Represents the activity of solving or creating puzzles.
        /// </summary>
        PuzzleMaking = 2,

        /// <summary>
        /// Represents playing video games.
        /// </summary>
        VideoGame = 4,

        /// <summary>
        /// Represents the sport of Badminton.
        /// </summary>
        Badminton = 8,

        /// <summary>
        /// Represents the sport of Table Tennis.
        /// </summary>
        TableTennis = 16
    }
}
