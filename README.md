##  LMAX-TradingSystem

###  Overview

  
This project simulates a simplified Trading System based on the concepts used in the `**LMAX Disruptor**` pattern. The system processes `OrderPlacedEvent` and applies Business Logic to simulate trades. It leverages `Event Sourcing` to store events for replay in case of a failure and implements a Failover Mechanism to recover from crashes by switching between multiple processors.

### Key Features

*   **Disruptor Pattern:** Uses a ring buffer pattern to process high-throughput events efficiently.
*   **Event Sourcing:** Stores every event, enabling the system to rebuild its state by replaying past events.
*   **Snapshotting:** Periodically takes a snapshot of the processor's state to speed up recovery.
*   **Failover Mechanism:** Simulates failover between multiple processors, allowing continued operation in the event of a crash.
*   **Diagnostics:** Supports replaying events for debugging and business diagnostics.  
     
    
    ### Getting Started
    
    ####  Prerequisites
    
      
    .NET 6.0 or higher  
    Visual Studio or any C# IDE  
    NuGet package Disruptor-net
    

###  How It Works

####  Event Sourcing

  
**OrderPlacedEvent**: Represents a customer placing an order (e.g., stock purchase).  
**EventStore**: Stores these events in a list (or a persistent store) to allow replaying events in case of failure. Each event has a Timestamp indicating when it was created.

#### Business Logic Processor

  
The BusinessLogicProcessor processes the OrderPlacedEvent to generate a TradeExecutedEvent. Each processed event is stored in the EventStore for future replay and is also used to update the system state, which can later be saved in a snapshot.

#### Snapshots

  
The system periodically takes snapshots of the current state (e.g., account balances).  
Snapshots are used to restore the system’s state quickly after a crash.

#### Failover Mechanism

  
**ReplicatedProcessor:**

This class manages multiple instances of BusinessLogicProcessor. If the primary processor crashes, the system fails over to a backup processor, which restores the state from the last snapshot and replays the events that occurred after the snapshot.
