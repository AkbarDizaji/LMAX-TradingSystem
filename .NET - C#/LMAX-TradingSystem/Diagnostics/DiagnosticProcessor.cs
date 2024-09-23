using LMAX_TradingSystem.EventSourcing;

namespace LMAX_TradingSystem.Diagnostics;

// Allows replaying the events in a separate domain model for debugging and business analysis
public class DiagnosticProcessor
{
    public void ReplayForDiagnostics(EventStore eventStore)
    {
        Console.WriteLine("Replaying events for diagnostics...");
        foreach (var orderEvent in eventStore.ReplayEvents())
        {
            Console.WriteLine($"Replaying order for {orderEvent.Symbol}, Quantity: {orderEvent.Quantity}");
        }
    }
}

