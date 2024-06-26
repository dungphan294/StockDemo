using StockDemo.Sources.ViewModel;

namespace StockDemo.Sources.View;

public partial class MainPage : ContentPage
{
    public MainPage(StocksViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
