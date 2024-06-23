using StockDemo.Sources.Services;

namespace StockDemo.Sources.ViewModel;

public partial class NewsViewModel : BaseViewModel
{
    IAlphaVantageService _alphaVantageService;
    public ObservableCollection<News> News { get; } = new();
    public NewsViewModel(AlphaVantageService alphaVantageService)
    {
        Title = "Stock News";
        this._alphaVantageService = alphaVantageService;
        Task.Run(async () => await GetNewsAsync());
    }

    [RelayCommand]
    async Task GoToDetailAsync(FeedItem feedItem)
    {
        if (feedItem is null)
            return;
        await Shell.Current.GoToAsync($"{nameof(View.NewsDetailPage)}", true,
            new Dictionary<string, object>
            {
                {"FeedItem", feedItem}
            });
    }

    [RelayCommand]
    async Task GetNewsAsync()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            var news = await _alphaVantageService.GetNews();
            if (News.Count != 0)
                News.Clear();

            foreach (var item in news)
                News.Add(item);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error",
                $"Unable to get news: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
