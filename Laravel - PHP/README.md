# LMAX Architecture-Inspired Trading System in Laravel

This project is a small trading sample built in Laravel, inspired by the LMAX Disruptor architecture. The system simulates the core principles of LMAX such as event sourcing, in-memory processing, and disruptors, adapted to Laravels environment.

## Key Concepts and Implementation
The LMAX architecture is designed for high-performance trading systems where processing speed and concurrency are critical. In this implementation, we use Laravel to simulate key components of the LMAX architecture.

**1.  In-Memory Processing
**
The core business logic of the system processes trades in-memory to minimize the performance impact of database operations. Events are stored in a queue instead of a database, ensuring that trades are handled quickly and efficiently.

Laravels job queues are used to simulate in-memory processing.
Since PHP is stateless and each request is separate, we simulate the in-memory processing by leveraging Laravels queue system to process events asynchronously.

**2.  Event Sourcing
**

The system follows the event sourcing pattern where each trade is stored as an event in a journal. These events are recorded in the order they occur, allowing the system to rebuild the current state by replaying the event history in case of failure.

All trades are stored as events in a durable log (event journal).
The system can replay events to rebuild its current state after a failure.

**3. Disruptors (Message Queue)
**

Since we cannot find any package for Disruptors for PHP, we simulate the disruptor pattern using Laravels queue system to handle asynchronous message passing between components. This allows for non-blocking processing, where trades are processed concurrently, and the system can recover from failures by switching to a different worker.

Laravel queues act as disruptors, ensuring that tasks are processed asynchronously.
The message queue system ensures that the system can handle a high volume of trades concurrently.

**4. Snapshots
**

To optimize recovery times, snapshots of the system’s state are periodically taken. This allows the system to avoid replaying all events from the beginning after a failure. Instead, it can restore from the most recent snapshot and then replay only the events that occurred after the snapshot.

Snapshots are taken at regular intervals to store the current state of the system.
In the event of a failure, the system restores from the latest snapshot and replays only recent events to recover.

## Implementation Plan
Here’s how the project implements the core concepts of the LMAX architecture in Laravel:

**1. Business Logic Processor
**

The business logic of trade processing is handled by a service class. This class processes each trade by executing business rules and emits events that are queued for further processing.

**2.Job Queues as Disruptors
**

Laravel’s built-in queue system acts as the disruptor, allowing trades to be processed asynchronously. Each trade event is pushed to a queue, where workers process them in the background, ensuring low latency and high throughput.

**3.Event Sourcing
**

Every trade is treated as an event and recorded in a log (event journal).
Events are replayed to recover the state of the system when necessary.

**4.Snapshots
**

Snapshots are created periodically to capture the current state of the system.
When the system restarts, it loads the most recent snapshot and replays only the events that occurred after the snapshot.
