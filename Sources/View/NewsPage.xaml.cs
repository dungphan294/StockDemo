using StockDemo.Sources.ViewModel;

namespace StockDemo.Sources.View;

public partial class NewsPage : ContentPage
{
	public NewsPage(NewsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}