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

var feedbacks = File.ReadAllLines(feedbackFilePath);
foreach (var feedback in feedbacks)
{
    // TODO: Call the method to get the sentiment
}
