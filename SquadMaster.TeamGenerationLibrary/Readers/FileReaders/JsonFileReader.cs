using SquadMaster.TeamGenerationLibrary.Converters;
using SquadMaster.TeamGenerationLibrary.Models.Member;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace SquadMaster.TeamGenerationLibrary.Readers.FileReaders
{
    /// <summary>
    /// JSON File Reader
    /// </summary>
    public class JsonFileReader : IFileReader
    {
        /// <summary>
        /// Read the JSON file at specified path and parse it to list of members
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public List<Member> Read(string filePath)
        {
            // Validate filePath
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(paramName: nameof(filePath), message: Resources.FilePathExceptionMessage);
            }
            try
            {
                string json = string.Empty;
                // Reading json from the json file
                json = File.ReadAllText(path: filePath);

                // Json serialization options
                JsonSerializerOptions options = new();
                options.Converters.Add(item: new PreferredGamesConverter());
                options.Converters.Add(item: new JsonStringEnumConverter());

                // Converting JSON to list of Members
                List<Member> members = JsonSerializer.Deserialize<List<Member>>
                    (
                        json: json,
                        options: options
                    ) ?? new List<Member>();
                return members;
            }
            catch (Exception ex) when (ex is ArgumentNullException ||
                                       ex is NotSupportedException ||
                                       ex is ArgumentException ||
                                       ex is PathTooLongException ||
                                       ex is DirectoryNotFoundException ||
                                       ex is IOException ||
                                       ex is UnauthorizedAccessException ||
                                       ex is FileNotFoundException ||
                                       ex is SecurityException ||
                                       ex is JsonException)
            {

            }
            catch (Exception)
            {

            }
            return new List<Member>();
        }
    }
}
