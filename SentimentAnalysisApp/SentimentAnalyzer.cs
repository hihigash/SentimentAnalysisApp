using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException(); // TODO:
        }
    }
}
