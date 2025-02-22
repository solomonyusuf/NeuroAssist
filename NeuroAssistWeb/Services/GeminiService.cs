using Microsoft.AspNetCore.Components.Forms;
using NeuroAssist.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace NeuroAssist.Services
{

    public class GeminiService
    {
        private readonly HttpClient _httpClient;
        
        private readonly FileConverterService _fileConverter;

        private readonly IConfiguration  _configuration;

        private string API_KEY;

        private const string API_URL = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent";

        public GeminiService(
            HttpClient httpClient, 
            IConfiguration configuration,
            FileConverterService fileConverter)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _fileConverter = fileConverter;
            API_KEY = _configuration.GetConnectionString("API_KEY");
        }

        public async Task<string> GetGeminiResponse(string prompt)
        {
            var requestData = new
            {
                prompt = new { text = prompt }
            };

            var response = await _httpClient.PostAsJsonAsync($"{API_URL}?key={API_KEY}", requestData);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GeminiResponse>();
                return result?.Candidates?[0]?.Content ?? "No response";
            }

            return "Error calling Gemini API";
        }
        
        public async Task<string> AnalyzeImage(IFormFile file, string prompt)
        {
            var base64Image = await _fileConverter.ConvertImageToBase64(file);

            var requestData = new
            {
                contents = new[]
                {
                new
                {
                    parts = new object[]
                    {
                        new { text = prompt },
                        new { inlineData = new { mimeType = file.ContentType, data = base64Image } }
                    }
                }
            }
            };

            var response = await _httpClient.PostAsJsonAsync($"{API_URL}?key={API_KEY}", requestData);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GeminiResponse>();
                return result?.Candidates?[0]?.Content ?? "No response";
            }

            return "Error processing image.";
        }

    }
}
