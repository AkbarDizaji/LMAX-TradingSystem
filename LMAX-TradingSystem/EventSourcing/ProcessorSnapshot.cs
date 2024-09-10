namespace LMAX_TradingSystem.EventSourcing;

public class ProcessorSnapshot
{
    public Dictionary<string, decimal> AccountBalances { get; set; } = new Dictionary<string, decimal>();
    public DateTime SnapshotTimestamp { get; set; }
}
