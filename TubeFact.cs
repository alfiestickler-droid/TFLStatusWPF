using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TFLStatusWPF
{

    public record TubeFact(
            [property: JsonPropertyName("id")] int Id,
            [property: JsonPropertyName("catagory")] string Catagory,
            [property: JsonPropertyName("title")] string Title,
            [property: JsonPropertyName("fact")] string Fact
            );
    public class TubeFacts
    {
        private static readonly List<TubeFact> facts;

        static TubeFacts()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "london_underground_facts-v2.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                facts = JsonSerializer.Deserialize<List<TubeFact>>(json) ?? [];
            }
            else
            {
                facts = [];
            }
        }

        public static string GetRandomFact()
        {
            if (facts.Count == 0)
                return "No facts available";

            TubeFact randomFact = facts[Random.Shared.Next(facts.Count)];
            return $"{randomFact.Title}: \n{randomFact.Fact}";
        }
    }
}