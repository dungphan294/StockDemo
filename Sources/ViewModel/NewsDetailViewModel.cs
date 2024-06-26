namespace StockDemo.Sources.ViewModel;

[QueryProperty("FeedItem", "FeedItem")]
public partial class NewsDetailViewModel : BaseViewModel
{
    public NewsDetailViewModel()
    { 
        Title = "News Detail";
    }

    [ObservableProperty]
    FeedItem feedItem;

    [RelayCommand]
    async Task OpenUrlAsync(string url)
    {
        if (!string.IsNullOrWhiteSpace(url))
        {
            try
            {
                Uri uri = new Uri(url);
                await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // You might want to log this exception or show an alert to the user
            }
        }
    }

}

