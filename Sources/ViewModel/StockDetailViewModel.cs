using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;


namespace StockDemo.Sources.ViewModel;

[QueryProperty("StockDetail", "StockDetail")]
public partial class StockDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    Stock stockDetail;
    public StockDetailViewModel()
    {
        Title = "Stock Detail";
        Series = Array.Empty<ISeries>();
        XAxes = Array.Empty<Axis>();
    }

    partial void OnStockDetailChanged(Stock value)
    {
        if (value == null || value.TimeSeries == null || !value.TimeSeries.Any())
        {
            // Handle null or empty stock detail gracefully
            Series = Array.Empty<ISeries>();
            XAxes = Array.Empty<Axis>();
            return;
        }
        var sortedTimeSeries = value.TimeSeries.OrderBy(x => x.Date).ToList();
        Series = new ISeries[]
        {
                new CandlesticksSeries<FinancialPointI>
                {
                    Values =sortedTimeSeries
                        .Select(x => new FinancialPointI(
                            Convert.ToDouble(x.High),
                            Convert.ToDouble(x.Open),
                            Convert.ToDouble(x.Close),
                            Convert.ToDouble(x.Low)))
                        .ToArray()
                }
        };

        XAxes = new[]
        {
                new Axis
                {
                    LabelsRotation = 15,
                    Labels = value.TimeSeries
                        .Select(x => x.Date.ToString("HH:mm"))
                        .ToArray()
                }
            };

        OnPropertyChanged(nameof(Series));
        OnPropertyChanged(nameof(XAxes));
    }

    public Axis[] XAxes { get; set; }

    public ISeries[] Series { get; set; }

}

