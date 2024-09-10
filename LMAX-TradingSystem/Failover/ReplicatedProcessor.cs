using LMAX_TradingSystem.BusinessLogic;
using LMAX_TradingSystem.EventSourcing;

namespace LMAX_TradingSystem.Failover;

// Simulate a failover mechanism where one processor can take over when another fails
public class ReplicatedProcessor
{
    private List<BusinessLogicProcessor> _processors = new List<BusinessLogicProcessor>();
    private int _currentPrimaryIndex = 0;

    public void AddProcessor(BusinessLogicProcessor processor)
    {
        _processors.Add(processor);
    }

    public void Failover()
    {
        Console.WriteLine("Failing over to a backup processor...");
        // Failover logic: switch to the next available processor



        // Increment to switch to the next processor (circular list)
        _currentPrimaryIndex = (_currentPrimaryIndex + 1) % _processors.Count;

        var backupProcessor = _processors[_currentPrimaryIndex]; // Example: select the second processor
        backupProcessor.RestoreFromSnapshotAndReplay(new ProcessorSnapshot());
        Console.WriteLine("Failover complete. Backup processor is now the primary processor.");

    }

    // Get the current active (primary) processor
    public BusinessLogicProcessor GetCurrentPrimaryProcessor()
    {
        return _processors[_currentPrimaryIndex];
    }
}
