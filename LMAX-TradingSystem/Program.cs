// See https://aka.ms/new-console-template for more information
using LMAX_TradingSystem.BusinessLogic;
using LMAX_TradingSystem.Domain;
using LMAX_TradingSystem.EventSourcing;
using LMAX_TradingSystem.Failover;

Console.WriteLine("Hello, World!");
// Create Event Store
// Create the event store (shared among processors)
EventStore eventStore = new EventStore();

// Create the snapshot
ProcessorSnapshot snapshot = new ProcessorSnapshot();

// Create multiple processors (primary and backups)
BusinessLogicProcessor primaryProcessor = new BusinessLogicProcessor(eventStore, snapshot);
BusinessLogicProcessor backupProcessor1 = new BusinessLogicProcessor(eventStore, snapshot);
BusinessLogicProcessor backupProcessor2 = new BusinessLogicProcessor(eventStore, snapshot);

// Create a replicated processor manager to handle failover
ReplicatedProcessor replicatedProcessor = new ReplicatedProcessor();

// Add the processors to the replicated processor manager
replicatedProcessor.AddProcessor(primaryProcessor);
replicatedProcessor.AddProcessor(backupProcessor1);
replicatedProcessor.AddProcessor(backupProcessor2);

// Use the primary processor to process some events
Console.WriteLine("Primary processor is processing events...");
var currentProcessor = replicatedProcessor.GetCurrentPrimaryProcessor();

for (int i = 0; i < 5; i++)
{
    OrderPlacedEvent orderEvent = new OrderPlacedEvent
    {
        OrderId = Guid.NewGuid().ToString(),
        Symbol = "AAPL",
        Quantity = 100 + i,
        Price = 150 + i
    };

    currentProcessor.ProcessEvent(orderEvent);
}

// Simulate taking a snapshot
currentProcessor.TakeSnapshot();

// Simulate a failure in the primary processor
Console.WriteLine("Simulating primary processor failure...");

// Call failover to switch to the backup processor
replicatedProcessor.Failover();

// Now, the backup processor is active
currentProcessor = replicatedProcessor.GetCurrentPrimaryProcessor();

// Continue processing events with the backup processor
Console.WriteLine("Backup processor is now processing events...");
for (int i = 5; i < 10; i++)
{
    OrderPlacedEvent orderEvent = new OrderPlacedEvent
    {
        OrderId = Guid.NewGuid().ToString(),
        Symbol = "GOOG",
        Quantity = 100 + i,
        Price = 2000 + i
    };

    currentProcessor.ProcessEvent(orderEvent);
}

Console.WriteLine("All events processed.");