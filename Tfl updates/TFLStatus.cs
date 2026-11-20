using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Media.Animation;

namespace TFLStatusWPF.Tfl_updates
{
    public static class TFLTubeInfo
    {
        public static async Task<List<TubeLine>?> TFLTubeNames() // When using async use task instead of void.
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");

            string url = "https://api.tfl.gov.uk/Line/Mode/tube/Status";

            try
            {


                // Fetch and automatically deserialize the JSON into C# objects
                return await client.GetFromJsonAsync<List<TubeLine>>(url);

                
            }
            catch (Exception ex)
            {
                //todo show error
                return null;
            }
        }

        public static async Task<List<string>?> TFLTubeStatus()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");

            string url = "https://api.tfl.gov.uk/Line/Mode/tube/Status";

            try
            {
               

                // Fetch and automatically deserialize the JSON into C# objects
                var lines = await client.GetFromJsonAsync<List<TubeLine>>(url);

                var statuses = new List<string>();

                if (lines != null)
                {
                    foreach (var line in lines)
                    {
                        if (line.LineStatuses != null && line.LineStatuses.Any())
                        {
                            var descriptions = line.LineStatuses
                                .Select(s => s.StatusSeverityDescription)
                                .Where(desc => !string.IsNullOrEmpty(desc));

                            statuses.Add($"{line.Name}: {string.Join(", ", descriptions)}");
                        }
                    }
                }
                return statuses;
            }
            catch (Exception ex)
            {
                //todo show error
                return null;
            }
        }

    }

    

    public class TubeLine
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lineStatuses")]
        public List<LineStatus>? LineStatuses { get; set; }
    }

    public class LineStatus
    {
        [JsonPropertyName("statusSeverityDescription")]
        public string StatusSeverityDescription { get; set; } = string.Empty;

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }
}
