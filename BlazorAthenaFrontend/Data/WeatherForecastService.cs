using System.Text.Json;

namespace BlazorAthenaFrontend.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsyncBak(DateOnly startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
        {
            using var client = new HttpClient();
            var response = await client.GetStreamAsync("https://localhost:7088/WeatherForecast"); //TODO hardcoded port?
            var forecasts = await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return forecasts.ToArray();

        }
    }
}
