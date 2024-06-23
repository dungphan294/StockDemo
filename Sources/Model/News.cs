// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
namespace StockDemo.Sources.Model;
public class News
{
    public string? Items { get; set; }
    public string? SentimentScoreDefinition { get; set; }
    public string? RelevanceScoreDefinition { get; set; }
    public List<FeedItem>? Feed { get; set; }
}

public class FeedItem
{
    public string? Title { get; set; }
    public string? Url { get; set; }
    public string? TimePublished { get; set; }
    public List<string>? Author { get; set; }
    public string? Summary { get; set; }
    public string? BannerImage { get; set; }
    public string? Source { get; set; }
    public string? SourceDomain { get; set; }
    public decimal OverallSentimentScore { get; set; }
    public string? OverallSentimentLabel { get; set; }
}