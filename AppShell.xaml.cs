using StockDemo.Sources.View;

namespace StockDemo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(StockDetailPage), typeof(StockDetailPage));
            Routing.RegisterRoute(nameof(NewsDetailPage), typeof(NewsDetailPage));
        }
    }
}
