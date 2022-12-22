using System.Text.Json.Serialization;

namespace OpenAIDotnet.Models.Request
{
    public class CreateCompletionRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set; }

        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }

        [JsonPropertyName("top_p")]
        public double? TopP { get; set; }

        [JsonPropertyName("n")]
        public int? CompletionCount { get; set; }

        [JsonPropertyName("stream")]
        public bool Stream { get; set; }

        [JsonPropertyName("logprobs")]
        public int? Logprobs { get; set; }

        [JsonPropertyName("echo")]
        public bool? Echo { get; set; }

        [JsonPropertyName("stop")]
        public string[] Stop { get; set; }

        [JsonPropertyName("presencePenalty")]
        public double? PresencePenalty { get; set; }

        [JsonPropertyName("frequency_penalty")]
        public double? FrequencyPenalty { get; set; }

        [JsonPropertyName("best_of")]
        public int? BestOf { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}
