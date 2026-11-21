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
            [property: JsonPropertyName("fact")] int Fact
            );
    public class TubeFacts
    {
        private readonly List<TubeFact> facts;

        public TubeFacts(string filePath = "london_underground_facts-v2.json")
        {
            string json = File.ReadAllText(filePath);
            facts = JsonSerializer.Deserialize<List<TubeFact>>(json) ?? [];
        }

        public string GetRandomFact()
        {
            if (facts.Count == 0)
                return "No facts avalible";

            TubeFact randomFact = facts[Random.Shared.Next(facts.Count)];
            return $"{randomFact.Title}: \n{randomFact.Fact}";
        }
    }
}
