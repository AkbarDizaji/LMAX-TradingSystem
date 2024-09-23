using LMAX_TradingSystem.Domain;
using LMAX_TradingSystem.EventSourcing;

namespace LMAX_TradingSystem.BusinessLogic;

public class BusinessLogicProcessor
{
    private EventStore _eventStore;
    private ProcessorSnapshot _snapshot;
    private bool _isReplaying = false;

    public BusinessLogicProcessor(EventStore eventStore, ProcessorSnapshot snapshot)
    {
        _eventStore = eventStore;
        _snapshot = snapshot;
    }

    public void ProcessEvent(OrderPlacedEvent orderEvent)
    {
        // Apply business logic here
        Console.WriteLine($"Processing order for {orderEvent.Symbol}, Quantity: {orderEvent.Quantity}, Price: {orderEvent.Price}");

        // Generate a trade event (simulate logic)
        TradeExecutedEvent tradeEvent = new TradeExecutedEvent
        {
            OrderId = orderEvent.OrderId,
            Symbol = orderEvent.Symbol,
            Quantity = orderEvent.Quantity,
            TradePrice = orderEvent.Price * 0.99m // Simulate execution logic
        };

        // Append to event store for replaying purposes
        _eventStore.AppendEvent(orderEvent);

        // Output the result of the event processing
        Console.WriteLine($"Trade executed for {tradeEvent.Symbol}, Quantity: {tradeEvent.Quantity}, Price: {tradeEvent.TradePrice}");
    }

    public void RestoreFromSnapshotAndReplay(ProcessorSnapshot snapshot)
    {
        // Step 1: Restore the processor's state from the snapshot
        Console.WriteLine("Restoring state from snapshot...");

        // Load snapshot state (restore important data like account balances, etc.)
        _snapshot = snapshot;

        // Example: Restore account balances from the snapshot
        foreach (var balance in _snapshot.AccountBalances)
        {
            Console.WriteLine($"Restored account: {balance.Key}, Balance: {balance.Value}");
        }

        // Step 2: Replay events that occurred after the snapshot
        _isReplaying = true;  // Set flag to prevent event appending during replay

        var eventsToReplay = _eventStore.GetEventsAfter(_snapshot.SnapshotTimestamp).ToList();

        foreach (var orderEvent in eventsToReplay)
        {
            // Process the event without adding it again to the event store
            ProcessEvent(orderEvent);
        }

        _isReplaying = false;  // Reset flag after replay is complete

        Console.WriteLine("State fully restored after replaying events.");
    }

    public void TakeSnapshot()
    {
        // Simulate taking a snapshot
        _snapshot = new ProcessorSnapshot
        {
            SnapshotTimestamp = DateTime.Now,
            // Add other state data here
        };
        _snapshot.AccountBalances.Remove("AAPL");
        _snapshot.AccountBalances.Add("AAPL", 10000);
        Console.WriteLine("Snapshot taken.");
    }

    private void ProcessEventWithoutStoreAppend(OrderPlacedEvent orderEvent)
    {
        // Apply business logic here
        Console.WriteLine($"Processing order for {orderEvent.Symbol}, Quantity: {orderEvent.Quantity}, Price: {orderEvent.Price}");

        // Generate a trade event (simulate logic)
        TradeExecutedEvent tradeEvent = new TradeExecutedEvent
        {
            OrderId = orderEvent.OrderId,
            Symbol = orderEvent.Symbol,
            Quantity = orderEvent.Quantity,
            TradePrice = orderEvent.Price * 0.99m // Simulate execution logic
        };

        // Output the result of the event processing
        Console.WriteLine($"Trade executed for {tradeEvent.Symbol}, Quantity: {tradeEvent.Quantity}, Price: {tradeEvent.TradePrice}");
    }
}
