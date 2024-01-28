using SentimentAnalysisApp;

if (args.Length != 1)
{
    Console.WriteLine("Usage: SentimentAnalysisApp <FeedbackFilePath>");
    return;
}

string feedbackFilePath = args[0];
if (!File.Exists(feedbackFilePath))
{
    Console.WriteLine($"File {feedbackFilePath} does not exist.");
    return;
}

Dictionary<Sentiment, List<string>> dictionary = new Dictionary<Sentiment, List<string>>();
var feedbacks = File.ReadAllLines(feedbackFilePath);
foreach (var feedback in feedbacks)
{
    var sentiment = await SentimentAnalyzer.GetSentiment(feedback);
    if (!dictionary.ContainsKey(sentiment))
    {
        dictionary.Add(sentiment, new List<string>());
    }
    dictionary[sentiment].Add(feedback);

    Console.WriteLine($"{sentiment}: {feedback}");
}

Console.WriteLine("\n=== ANALYSIS RESULT ===");
foreach (var (key, value) in dictionary)
{
    Console.WriteLine($"{key}: {((double)value.Count / feedbacks.Length) * 100}% ({value.Count})");
}
