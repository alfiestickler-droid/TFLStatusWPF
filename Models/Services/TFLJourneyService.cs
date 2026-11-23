using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using TFLStatusWPF.Models;

namespace TFLStatusWPF.Models.Services
{
    public class TFLJourneyService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string AppKey = "d7ca74ea5219469b907b739d5e51d630";

        public async Task<JourneyResponse?> GetJourneyAsync(string fromStationId, string toStationId)
        {

            string url = $"https://tfl.gov.uk{fromStationId}/to/{toStationId}?mode=tube&app_key={AppKey}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();//this is what checks if the get request was a success

                string jsonResponse = await response.Content.ReadAsStringAsync();//saves Tfl reply as a raw JSON string.

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive=true
                };

                var data = JsonSerializer.Deserialize<TflStopPointResponse>(jsonResponse, options);

                if (data?.StopPoints == null)
                    return new List<StationItem>();

                return data.StopPoints
                    .Where(s => s.StopType == "NaptanMetroStation")
                    .Select(s => new StationItem
                    {
                        Id = s.NaptanId,
                        Name = s.CommonName.Replace(" Underground Station", "").Trim()
                    })

                    .GroupBy(s => s.Name)
                    .Select(g => g.First())
                    .OrderBy(s => s.Name)
                    .ToList();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"API Request Failed: {ex.Message}");
                return null;
            }

        }
    }
}
