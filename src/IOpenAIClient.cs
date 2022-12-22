using OpenAIDotnet.Models.Response;

namespace OpenAIDotnet
{
    public interface IOpenAIClient
    {
        Task<CreateCompletionResponse> CreateCompletion();
    }
}
