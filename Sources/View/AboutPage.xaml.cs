using StockDemo.Sources.ViewModel;
using StockDemo.Sources.ViewModels;
namespace StockDemo.Sources.View;

public partial class AboutPage : ContentPage
{
	public AboutPage(AboutViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}