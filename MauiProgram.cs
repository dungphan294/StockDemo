using Microsoft.Extensions.Logging;
using StockDemo.Sources.Services;
using StockDemo.Sources.View;
using StockDemo.Sources.ViewModel;
using StockDemo.Sources.ViewModels;

namespace StockDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<AlphaVantageService>();
            
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<StockDetailPage>();
            builder.Services.AddSingleton<NewsPage>();
            builder.Services.AddTransient<NewsDetailPage>();
            builder.Services.AddSingleton<AboutPage>();
            
            builder.Services.AddSingleton<StocksViewModel>();
            builder.Services.AddSingleton<NewsViewModel>();
            builder.Services.AddTransient<NewsDetailViewModel>();
            builder.Services.AddSingleton<AboutViewModel>();

            return builder.Build();
        }
    }
}
