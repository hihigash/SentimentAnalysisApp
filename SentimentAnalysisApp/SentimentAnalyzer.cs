using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;

namespace SentimentAnalysisApp
{
    internal enum Sentiment
    {
        Positive,
        Neutral,
        Negative
    }

    internal static class SentimentAnalyzer
    {
        public static async Task<Sentiment> GetSentiment(string feedback)
        {
            OpenAIClient client = new OpenAIClient(
              new Uri("https://oai-yourname-handsonlab-sdc.openai.azure.com/"),
              new AzureKeyCredential(Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY")));

            Response<ChatCompletions> responseWithoutStream = await client.GetChatCompletionsAsync(
            "gpt-35-turbo-auto",
            new ChatCompletionsOptions()
            {
                Messages =
              {
      new ChatMessage(ChatRole.System, @"あなたはユーザーからのフィードバックを肯定(Positive)、中立(Neutral)、否定(Negative) の３つ種類に分類します。
分析結果は、下記の JSON 形式で返却してください。
{
  ""sentiment"": ""{Positive|Negative|Neutral}""
}"),

                },
                Temperature = (float)0.5,
                MaxTokens = 800,


                NucleusSamplingFactor = (float)0.95,
                FrequencyPenalty = 0,
                PresencePenalty = 0,
            });

            ChatCompletions response = responseWithoutStream.Value;
            //TODO:
            throw new NotImplementedException();
        }
    }
}
