using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TFLStatusWPF.Models;

namespace TFLStatusWPF.Models.Services
{
    public class TFLJourneyService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string AppKey = "d7ca74ea5219469b907b739d5e51d630";

        public async Task<JourneyResponse?> GetJourneyAsync(string fromStationId, string toStationId)
        {
            string host = "api." + "tfl.gov.uk";
            string url = $"https://{host}/Journey/JourneyResults/{fromStationId}/to/{toStationId}?mode=tube&app_key={AppKey}";


            try
            {
                if (!_httpClient.DefaultRequestHeaders.Contains("User-Agent"))
                {
                    _httpClient.DefaultRequestHeaders.Add("User-Agent", "TFLStatusWPFApp/1.0");
                }

                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<JourneyResponse>(jsonResponse, options);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Journey API Request Failed: {ex.Message}");
                return null;
            }
        }

        public async Task<List<StationItem>> GetStationsAsync()
        {
            string host = "api." + "tfl.gov.uk";
            string url = $"https://{host}/StopPoint/Mode/tube?app_key={AppKey}";


            try
            {
                if (!_httpClient.DefaultRequestHeaders.Contains("User-Agent"))
                {
                    _httpClient.DefaultRequestHeaders.Add("User-Agent", "TFLStatusWPFApp/1.0");
                }

                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                List<StopPointDto>? rawPoints = null;

                // Check if TfL returned a raw JSON array '[' or a wrapped object '{'
                if (jsonResponse.TrimStart().StartsWith("["))
                {
                    rawPoints = JsonSerializer.Deserialize<List<StopPointDto>>(jsonResponse, options);
                }
                else
                {
                    var wrappedData = JsonSerializer.Deserialize<TflStopPointResponse>(jsonResponse, options);
                    rawPoints = wrappedData?.StopPoints;
                }

                if (rawPoints == null)
                    return new List<StationItem>();

                return rawPoints
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
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Stations API Request Failed: {ex.Message}");
                return new List<StationItem>();
            }
        }
    }
}
