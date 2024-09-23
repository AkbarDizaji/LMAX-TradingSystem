namespace LMAX_TradingSystem.Domain;

public class OrderPlacedEvent
{
    public string OrderId { get; set; }
    public string Symbol { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime Timestamp { get; set; }  

    public OrderPlacedEvent()
    {
        // Automatically set the timestamp when the event is created
        Timestamp = DateTime.Now;
    }
}
