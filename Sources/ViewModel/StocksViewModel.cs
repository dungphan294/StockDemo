using StockDemo.Sources.Services;

namespace StockDemo.Sources.ViewModel;

public partial class StocksViewModel: BaseViewModel
{
    IAlphaVantageService _alphaVantageService;

    public ObservableCollection<Stock> Stocks { get; } = new();
    
    public StocksViewModel(AlphaVantageService alphaVantageService)
    {
        Title = "Homepage";
        this._alphaVantageService = alphaVantageService; 
        Task.Run(async () => await GetStockAsync());
    }

    [RelayCommand]
    async Task GoToDetailAsync(Stock detail)
    {
        if (detail is null)
            return;
        await Shell.Current.GoToAsync($"{nameof(View.StockDetailPage)}", true,
            new Dictionary<string, object>
            {
                {"StockDetail", detail},
            });
    }

    [RelayCommand]
    async Task GetStockAsync()
    {
        if(IsBusy) return;
        try
        {
            IsBusy = true;  
            var stock = await _alphaVantageService.GetAllStockData();
            if (Stocks.Count != 0)
                Stocks.Clear();

            foreach (var item in stock)
                Stocks.Add(item);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error",
                $"Unable to get stock: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
