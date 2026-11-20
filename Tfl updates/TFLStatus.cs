using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Media.Animation;

namespace TFLStatusWPF.Tfl_updates
{
    public static class TFLStatus
    {
        public static async Task<List<TubeLine>?> TFL() // When using async use task instead of void.
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
