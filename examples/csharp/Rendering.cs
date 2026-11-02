// JavaScript Rendering API – C# example (.NET 6+, top-level statements)
// Usage: dotnet new console -n Example && copy this file to Program.cs, then BROWSERSOLVER_API_KEY=your-key dotnet run
using System.Text;
using System.Text.Json;

var apiKey = Environment.GetEnvironmentVariable("BROWSERSOLVER_API_KEY") ?? throw new InvalidOperationException("Set BROWSERSOLVER_API_KEY");
using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(120) };
http.DefaultRequestHeaders.Add("x-api-key", apiKey);

var query = "query=" + Uri.EscapeDataString("https://quotes.toscrape.com/js/");
var response = await http.GetAsync("https://api.browsersolver.com/v1/website/rendering" + (query.Length > 0 ? "?" + query : ""));
if (!response.IsSuccessStatusCode)
{
    Console.Error.WriteLine($"HTTP {(int)response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
    return;
}

using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
Console.WriteLine(JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true }));
