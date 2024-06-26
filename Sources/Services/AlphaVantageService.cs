namespace StockDemo.Sources.Services;

public class AlphaVantageService : IAlphaVantageService
{
    HttpClient _httpClient;

    public string Symbol { get; set; }
    public string APIKey { get; set; }
    public int Interval { get; set; }
    public AlphaVantageService()
    {
        _httpClient = new HttpClient();
        Symbol = "IBM";
        APIKey = "demo";
        Interval = 5;
    }

    List<Stock> StockList = new();
    List<News> NewsList = new();
    
    public async Task<List<Stock>> GetStockData()
    {
        if (StockList.Count > 0) return StockList;
        string urlData = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={Symbol}&interval={Interval}min&apikey={APIKey}";
        string urlAbout = $"https://www.alphavantage.co/query?function=OVERVIEW&symbol={Symbol}&apikey={APIKey}";
        var responseData = await _httpClient.GetStringAsync(urlData);
        var responseAbout = await _httpClient.GetStringAsync(urlAbout);
        var rootData = JsonDocument.Parse(responseData).RootElement;
        var rootAbout = JsonDocument.Parse(responseAbout).RootElement;


        var stock = new Stock
        {
            MetaData = new MetaData(),
            TimeSeries = new List<StockPrice>(),
            CompanyInfo = new CompanyInfo()
        };

        // ABOUT
        stock.CompanyInfo.Symbol = rootAbout.GetProperty("Symbol").GetString();
        stock.CompanyInfo.AssetType = rootAbout.GetProperty("AssetType").GetString();
        stock.CompanyInfo.Name = rootAbout.GetProperty("Name").GetString();
        stock.CompanyInfo.Description = rootAbout.GetProperty("Description").GetString();
        stock.CompanyInfo.CIK = rootAbout.GetProperty("CIK").GetString();
        stock.CompanyInfo.Exchange = rootAbout.GetProperty("Exchange").GetString();
        stock.CompanyInfo.Currency = rootAbout.GetProperty("Currency").ToString();
        stock.CompanyInfo.Country = rootAbout.GetProperty("Country").ToString();
        stock.CompanyInfo.Sector = rootAbout.GetProperty("Sector").GetString();
        stock.CompanyInfo.Industry = rootAbout.GetProperty("Industry").GetString();
        stock.CompanyInfo.Address = rootAbout.GetProperty("Address").GetString();

        // META DATA
        if (rootData.TryGetProperty($"Meta Data", out var metaDataNode))
        {
            stock.MetaData.Information = metaDataNode.GetProperty("1. Information").GetString();
            stock.MetaData.Symbol = metaDataNode.GetProperty("2. Symbol").GetString();
            stock.MetaData.LastRefreshed = metaDataNode.GetProperty("3. Last Refreshed").GetString();
            stock.MetaData.Interval = metaDataNode.GetProperty("4. Interval").GetString();
            stock.MetaData.OutputSize = metaDataNode.GetProperty("5. Output Size").GetString();
            stock.MetaData.TimeZone = metaDataNode.GetProperty("6. Time Zone").GetString();
        }

        // TIME SERIES
        if (rootData.TryGetProperty($"Time Series ({Interval}min)", out var timeSeriesNode))
        {
            foreach (var item in timeSeriesNode.EnumerateObject())
            {
                var timestamp = DateTime.Parse(item.Name);
                var stockData = item.Value;

                var stockPrice = new StockPrice
                {
                    Date = timestamp,
                    Open = Convert.ToDecimal(stockData.GetProperty("1. open").ToString()),
                    High = Convert.ToDecimal(stockData.GetProperty("2. high").ToString()),
                    Low = Convert.ToDecimal(stockData.GetProperty("3. low").ToString()),
                    Close = Convert.ToDecimal(stockData.GetProperty("4. close").ToString())
                };

                stock.TimeSeries.Add(stockPrice);
            }
            StockList.Add(stock);
        }
        return StockList;
    }


    public async Task<List<News>> GetNews()
    {
        if (NewsList?.Count > 0)
            return NewsList;
        var url = "https://www.alphavantage.co/query?function=NEWS_SENTIMENT&tickers=AAPL&apikey=demo";
        var response = await _httpClient.GetStringAsync(url);
        var root = JsonDocument.Parse(response).RootElement;

        var topNews = new News
        {
            Items = root.GetProperty("items").GetString(),
            SentimentScoreDefinition = root.GetProperty("sentiment_score_definition").GetString(),
            RelevanceScoreDefinition = root.GetProperty("relevance_score_definition").GetString(),
            Feed = new List<FeedItem>()
        };

        if (root.TryGetProperty("feed", out var feed))
        {
            foreach (var item in feed.EnumerateArray())
            {
                var feedItem = new FeedItem
                {
                    Title = item.GetProperty("title").GetString(),
                    Url = item.GetProperty("url").GetString(),
                    TimePublished = item.GetProperty("time_published").GetString(),
                    Author = item.GetProperty("authors").EnumerateArray().Select(author => author.GetString()).ToList(),
                    Summary = item.GetProperty("summary").GetString(),
                    BannerImage = item.GetProperty("banner_image").GetString(),
                    Source = item.GetProperty("source").GetString(),
                    SourceDomain = item.GetProperty("source_domain").GetString(),
                    OverallSentimentScore = item.GetProperty("overall_sentiment_score").GetDecimal(),
                    OverallSentimentLabel = item.GetProperty("overall_sentiment_label").GetString()
                };
                topNews.Feed.Add(feedItem);
            }
        }
        NewsList.Add(topNews);

        //using var stream = await FileSystem.OpenAppPackageFileAsync("newsdata.json");
        //using var reader = new StreamReader(stream);
        //var contents = await reader.ReadToEndAsync();
        //newsList = JsonSerializer.Deserialize<List<News>>(contents);
        return NewsList;
    }

    public Task LoadAllSymbolDataAsync()
    {
        throw new NotImplementedException();
    }

    public Task LoadAllNewsDataAsync()
    {
        throw new NotImplementedException();
    }
}


