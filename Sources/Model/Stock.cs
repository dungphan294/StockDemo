namespace StockDemo.Sources.Model;
public class Stock
{
    public MetaData? MetaData { get; set; }
    public IList<StockPrice>? TimeSeries { get; set; }
    public CompanyInfo? CompanyInfo { get; set; }
}
public class StockPrice
{
    public DateTime Date { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }

}
public class MetaData
{
    public string? Information { get; set; }
    public string? Symbol { get; set; }
    public string? LastRefreshed { get; set; }
    public string? Interval { get; set; }
    public string? OutputSize { get; set; }
    public string? TimeZone { get; set; }
}
public class CompanyInfo
{
    public string? Symbol { get; set; }
    public string? AssetType { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? CIK { get; set; }
    public string? Exchange { get; set; }
    public string? Currency { get; set; }
    public string? Country { get; set; }
    public string? Sector { get; set; }
    public string? Industry { get; set; }
    public string? Address { get; set; }
    public string? FiscalYearEnd { get; set; }
    public DateOnly LatestQuarter { get; set; }
    public decimal MarketCapitalization { get; set; } // Assuming market cap is a number
    public decimal EBITDA { get; set; } // Assuming EBITDA is a number
    public decimal PERatio { get; set; }
    public decimal PEGRatio { get; set; }
    public decimal BookValue { get; set; }
    public decimal DividendPerShare { get; set; }
    public decimal DividendYield { get; set; }
    public decimal EPS { get; set; }
    public decimal RevenuePerShareTTM { get; set; }
    public decimal ProfitMargin { get; set; }
    public decimal OperatingMarginTTM { get; set; }
    public decimal ReturnOnAssetsTTM { get; set; }
    public decimal ReturnOnEquityTTM { get; set; }
    public decimal RevenueTTM { get; set; }
    public decimal GrossProfitTTM { get; set; }
    public decimal DilutedEPSTTM { get; set; }
    public decimal QuarterlyEarningsGrowthYOY { get; set; }
    public decimal QuarterlyRevenueGrowthYOY { get; set; }
    public decimal AnalystTargetPrice { get; set; }
    public int AnalystRatingStrongBuy { get; set; }
    public int AnalystRatingBuy { get; set; }
    public int AnalystRatingHold { get; set; }
    public int AnalystRatingSell { get; set; }
    public int AnalystRatingStrongSell { get; set; }
    public decimal TrailingPE { get; set; }
    public decimal ForwardPE { get; set; }
    public decimal PriceToSalesRatioTTM { get; set; }
    public decimal PriceToBookRatio { get; set; }
    public decimal EVToRevenue { get; set; }
    public decimal EVToEBITDA { get; set; }
    public decimal Beta { get; set; }
    public decimal _52WeekHigh { get; set; }
    public decimal _52WeekLow { get; set; }
    public decimal _50DayMovingAverage { get; set; }
    public decimal _200DayMovingAverage { get; set; }
    public long SharesOutstanding { get; set; }
    public DateOnly DividendDate { get; set; }
    public DateOnly ExDividendDate { get; set; }
}
