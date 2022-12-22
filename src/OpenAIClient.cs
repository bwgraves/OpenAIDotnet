using OpenAIDotnet.Models.Response;
using System.Net.Http.Headers;
using System.Text.Json;

namespace OpenAIDotnet
{
    public class OpenAIClient : IOpenAIClient
    {
        private const string BASE_URI = "https://api.openai.com/v1/";

        private readonly HttpClient httpClient;

        public OpenAIClient(string apiKey)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BASE_URI);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        public async Task<CreateCompletionResponse> CreateCompletion()
        {
            var response = await httpClient.GetAsync("completions");
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<CreateCompletionResponse>(stream);
        }
    }
}
