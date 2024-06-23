namespace StockDemo.Sources.View;

public partial class StockDetailPage : ContentPage
{
	public StockDetailPage(ViewModel.StockDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}