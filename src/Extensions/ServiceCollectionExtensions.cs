using Microsoft.Extensions.DependencyInjection;

namespace OpenAIDotnet.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOpenAI(this IServiceCollection serviceCollection, string apiKey)
        {
            serviceCollection.AddScoped<IOpenAIClient>(c => new OpenAIClient(apiKey));
            return serviceCollection;
        }
    }
}
