namespace OpenAIDotnet.Models.Request
{
    public class CreateCompletionRequest
    {
        public string Model { get; set; }
        public string Prompt { get; set; }
        public int MaxTokens { get; set; }
        public double Temperature { get; set; }
        public double TopP { get; set; }
        public int CompletionCount { get; set; }
        public bool Steam { get; set; }
        public int Logprobs { get; set; }
        public bool Echo { get; set; }
        public string[] Stop { get; set; }
        public double PresencePenalty { get; set; }
        public double FrequencyPenalty { get; set; }
        public int BestOf { get; set; }
        public string User { get; set; }
    }
}
