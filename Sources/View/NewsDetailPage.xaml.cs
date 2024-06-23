
namespace StockDemo.Sources.View;

public partial class NewsDetailPage : ContentPage
{
	public NewsDetailPage(ViewModel.NewsDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

}