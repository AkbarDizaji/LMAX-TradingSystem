using Disruptor;
using LMAX_TradingSystem.BusinessLogic;
using LMAX_TradingSystem.Domain;

namespace LMAX_TradingSystem.DisruptorSetup;


// Factory for creating new instances of OrderPlacedEvent
public class OrderEventFactory
{
    public OrderPlacedEvent NewInstance()
    {
        return new OrderPlacedEvent();
    }
}

// Event handler for processing OrderPlacedEvent
public class OrderEventHandler : IEventHandler<OrderPlacedEvent>
{
    private readonly BusinessLogicProcessor _processor;

    public OrderEventHandler(BusinessLogicProcessor processor)
    {
        _processor = processor;
    }

    public void OnEvent(OrderPlacedEvent data, long sequence, bool endOfBatch)
    {
        _processor.ProcessEvent(data); // Pass the event to the business logic processor
    }
}