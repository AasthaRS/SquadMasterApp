using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using SquadMaster.TeamGenerationLibrary.Models;

namespace SquadMaster.TeamGenerationLibrary.Converters
{
    internal class PreferredGamesConverter : JsonConverter<Game>
    {
        public override Game Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Game result = Game.None;
            try
            {
                List<string> games = JsonSerializer.Deserialize<List<string>>(ref reader, options) ?? new List<string>();

                // Convert Games array in JSON to Enum value
                foreach (string game in games)
                {
                    if (Enum.TryParse(game, true, out Game parsedGame))
                    {
                        result ^= parsedGame;
                    }
                }
            }
            catch (Exception ex) when (ex is JsonException ||
                                       ex is ArgumentException ||
                                       ex is NotSupportedException ||
                                       ex is InvalidOperationException)
            {
                result = Game.None;
            }
            catch (Exception)
            {
                result = Game.None;
            }
            return result;
        }

        public override void Write(Utf8JsonWriter writer, Game value, JsonSerializerOptions options)
        {
            try
            {
                JsonSerializer.Serialize(writer, value.ToString(), options);
            }
            catch (Exception ex) when (ex is ArgumentNullException ||
                                      ex is NotSupportedException)
            {
                JsonSerializer.Serialize(writer, String.Empty);
            }
        }
    }
}
