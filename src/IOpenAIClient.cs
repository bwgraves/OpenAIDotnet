using OpenAIDotnet.Models.Request;
using OpenAIDotnet.Models.Response;

namespace OpenAIDotnet
{
    public interface IOpenAIClient
    {
        Task<CreateCompletionResponse> CreateCompletion(CreateCompletionRequest createCompletion);
    }
}
