using LMAX_TradingSystem.Domain;

namespace LMAX_TradingSystem.EventSourcing;

public class EventStore
{
    private List<OrderPlacedEvent> _eventJournal = new List<OrderPlacedEvent>();

    public void AppendEvent(OrderPlacedEvent orderEvent)
    {
        _eventJournal.Add(orderEvent);
    }


    // Retrieve events that occurred after a specific timestamp
    public IEnumerable<OrderPlacedEvent> GetEventsAfter(DateTime snapshotTimestamp)
    {
        return _eventJournal.Where(e => e.Timestamp > snapshotTimestamp);
    }

    public IEnumerable<OrderPlacedEvent> ReplayEvents()
    {
        return _eventJournal;
    }
}
