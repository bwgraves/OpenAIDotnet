namespace OpenAIDotnet.Models.Response
{
    public class CreateCompletionResponse
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public int Created { get; set; }
        public string Model { get; set; }
        public List<Choice> Choices { get; set; }
        public class Choice
        {
            public string Text { get; set; }
            public int Index { get; set; }
            public int Logprobs { get; set; }
            public string FinishReason { get; set; }
        }
        public UsageProperties Usage { get; set; }
        public class UsageProperties
        {
            public int PromptTokens { get; set; }
            public int CompletionTokens { get; set; }
            public int TotalTokens { get; set; }
        }
    }
}
