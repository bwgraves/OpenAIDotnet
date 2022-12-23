using OpenAIDotnet.Models.Request;
using OpenAIDotnet.Models.Response;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAIDotnet
{
    /// <summary>
    /// A wrapper class around the OpenAI api, containg methods to interact with their endpoints.
    /// See the API reference docs here: https://beta.openai.com/docs/api-reference/
    /// </summary>
    public class OpenAIClient : IOpenAIClient
    {
        private const string BASE_URI = "https://api.openai.com/v1/";

        private readonly HttpClient httpClient;

        /// <summary>
        /// Constructor which sets up the HTTP client to auth with the given api key.
        /// </summary>
        /// <param name="apiKey">Your API key.</param>
        public OpenAIClient(string apiKey)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BASE_URI);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        #region Completions

        /// <summary>
        /// <see cref="CreateCompletionAsync(CreateCompletionRequest)"/>
        /// </summary>
        public async Task<CreateCompletionResponse> CreateCompletionAsync(CreateCompletionRequest createCompletion)
        {
            if (string.IsNullOrWhiteSpace(createCompletion.Model))
            {
                throw new ArgumentNullException(nameof(createCompletion.Model), "The model value was not set on the completion request");
            }

            return await MakeRequestAsync<CreateCompletionResponse>(createCompletion);
        }

        /// <summary>
        /// <see cref="CreateCompletionAsync(string, string)"/>
        /// </summary>
        public async Task<CreateCompletionResponse> CreateCompletionAsync(string prompt, string model = AIModels.TEXT_DAVINCI_003)
        {
            var request = new CreateCompletionRequest
            {
                Prompt = prompt,
                Model = model
            };

            return await CreateCompletionAsync(request);
        }

        #endregion

        /// <summary>
        /// Helper method to fire off a request to the OpenAI api.
        /// </summary>
        /// <typeparam name="T">The object to deserialise the response content to.</typeparam>
        /// <param name="requestObj">The request body.</param>
        /// <returns>A populated T if successful.</returns>
        private async Task<T> MakeRequestAsync<T>(object requestObj)
        {
            var serializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            var body = JsonSerializer.Serialize(requestObj, serializerOptions);
            var request = new StringContent(body, System.Text.Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await httpClient.PostAsync("completions", request);

            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(stream, serializerOptions);
        }
    }
}
