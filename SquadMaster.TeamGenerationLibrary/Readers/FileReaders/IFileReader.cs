using SquadMaster.TeamGenerationLibrary.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.Readers.FileReaders
{
    /// <summary>
    /// File Reader
    /// </summary>
    internal interface IFileReader
    {
        /// <summary>
        /// Read the file at specified path and parse it to list of members
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        List<Member> Read(string filePath);
    }
}
