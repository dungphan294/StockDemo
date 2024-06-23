namespace StockDemo.Sources.Services
{
    internal interface IAlphaVantageService
    {
        string Symbol { get; set; }
        string APIKey { get; set; }
        int Interval { get; set; }
        Task LoadAllSymbolDataAsync();
        Task LoadAllNewsDataAsync();
        Task<List<Stock>> GetStockData();
        Task<List<News>> GetNews();
    }
}
