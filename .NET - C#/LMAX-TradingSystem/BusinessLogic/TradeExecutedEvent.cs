namespace LMAX_TradingSystem.BusinessLogic;

public class TradeExecutedEvent
{
    public string OrderId { get; set; }
    public string Symbol { get; set; }
    public int Quantity { get; set; }
    public decimal TradePrice { get; set; }
}
