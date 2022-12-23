using OpenAIDotnet.Models.Request;
using OpenAIDotnet.Models.Response;

namespace OpenAIDotnet
{
    /// <summary>
    /// Interface for an OpenAI api client.
    /// </summary>
    public interface IOpenAIClient
    {
        /// <summary>
        /// Calls the Create Completion endpoint with request object.
        /// </summary>
        /// <param name="createCompletion">The request object with all properties taken by the endpoint.</param>
        /// <returns>A populated <see cref="CreateCompletionResponse"/> if successful.</returns>
        Task<CreateCompletionResponse> CreateCompletionAsync(CreateCompletionRequest createCompletion);

        /// <summary>
        /// Calls the Create Completion endpoint with the given prompt and model.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="model">The AI model, e.g. "text-davinci-003".</param>
        /// <returns>A populated <see cref="CreateCompletionResponse"/> if successful.</returns>
        Task<CreateCompletionResponse> CreateCompletionAsync(string prompt, string model = AIModels.TEXT_DAVINCI_003);
    }
}
