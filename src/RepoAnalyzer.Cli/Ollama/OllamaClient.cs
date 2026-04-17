using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class OllamaClient
{
    private readonly HttpClient _httpClient;

    public OllamaClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:11434"),
            Timeout = TimeSpan.FromMinutes(5)
        };
    }

    public async Task<string> GenerateAsync(string prompt)
    {
        var requestBody = new
        {
            model = "llama3",
            prompt,
            stream = false
        };

        var json = JsonSerializer.Serialize(requestBody);

        var response = await _httpClient.PostAsync(
            "/api/generate",
            new StringContent(json, Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(responseContent);

        return doc.RootElement.GetProperty("response").GetString() ?? "No response received.";
    }
}

