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
        Title = "Error";
        Series = new ISeries[]
          {
                new CandlesticksSeries<StockPrice>()
          };

        XAxes = new[]
        {
                new Axis
                {
                    LabelsRotation = 15
                }
            };
    }

    

    public Axis[] XAxes { get; set; }

    public ISeries[] Series { get; set; }

    //private void UpdateChart()
    //{
    //    Series = new ISeries[]
    //    {
    //            new CandlesticksSeries<FinancialPointI>
    //            {
    //                Values = stockDetail.TimeSeries
    //                .Select(x => new FinancialPointI((double)x.High, (double)x.Open, (double)x.Close, (double)x.Low))
    //                .ToArray()
    //            }
    //    };

    //    XAxes = new[]
    //    {
    //            new Axis
    //            {
    //                LabelsRotation = 15,
    //                Labels = stockDetail.TimeSeries
    //                    .Select(x => x.Date.ToString("dd-MM-yy HH:mm:ss"))
    //                    .ToArray()
    //            }
    //        };

    //    OnPropertyChanged(nameof(Series));
    //    OnPropertyChanged(nameof(XAxes));
    //}
}
