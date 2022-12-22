using OpenAIDotnet.Models.Request;
using OpenAIDotnet.Models.Response;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        public async Task<CreateCompletionResponse> CreateCompletion(CreateCompletionRequest createCompletion)
        {
            // Just hardcode the model for now
            createCompletion.Model = "text-davinci-003";

            var serializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            var body = JsonSerializer.Serialize(createCompletion, serializerOptions);
            var request = new StringContent(body, System.Text.Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await httpClient.PostAsync("completions", request);

            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<CreateCompletionResponse>(stream, serializerOptions);
        }
    }
}
