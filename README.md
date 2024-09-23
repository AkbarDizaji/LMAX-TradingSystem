[![Powered by .NET](https://img.shields.io/badge/Powered%20by-.NET-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![LMAX Architecture](https://img.shields.io/badge/Architecture-LMAX-blue?style=flat)](https://martinfowler.com/articles/lmax.html)
[![High Performance](https://img.shields.io/badge/High-Performance-orange?style=flat)](https://github.com/yourusername/yourrepo)
[![Asynchronous](https://img.shields.io/badge/Asynchronous-Programming-brightgreen?style=flat)](https://github.com/yourusername/yourrepo)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![GitHub stars](https://img.shields.io/github/stars/AkbarDizaji/LMAX-TradingSystem.svg?style=social&label=Star&maxAge=2592000)](https://github.com/AkbarDizaji/LMAX-TradingSystem/stargazers/)

# LMAX Trading System

This project provides a multi-language implementation of the LMAX Disruptor architecture for building high-performance trading platforms. The LMAX architecture is a low-latency, high-throughput system designed for handling millions of trades per second. It is an in-memory, event-sourced system using a pattern known as Disruptor to achieve high concurrency without the need for traditional locks.
## Implemented Languages
**PHP (Laravel): **Full implementation of LMAX architecture.
**C# (.NET): **Full implementation of LMAX architecture.
## Overview of LMAX Architecture
LMAX is a highly efficient architecture, designed to process a high volume of transactions in financial trading systems. The core components include:

- **In-memory Business Logic Processor:** Handles all business logic in a single-threaded manner for simplicity and speed.
- **Disruptor Pattern: **A high-performance concurrency framework that replaces traditional queues with a lock-free ring buffer.
- **Event Sourcing:** All changes are captured as a series of events, making the system resilient to failures by replaying events from a durable store.
## Features
- **In-memory processing:** All transactions are processed in memory, reducing I/O overhead and increasing speed.
- **Event Sourcing:** Ensures system state can always be rebuilt by replaying events.
- **Concurrency:** Utilizes the Disruptor pattern to handle concurrent tasks without the need for locks.
- **Multi-language support:** Current implementations in:
	- PHP (Laravel)
	- C# (.NET)

## Project Structure
**/Laravel-PHP**: Contains the LMAX implementation using the Laravel framework in PHP.
**/.NET-C#**: Contains the LMAX implementation using .NET in C#.

Each language folder contains its own implementation, including the core architecture and a sample application demonstrating how LMAX can be used for handling high-frequency transactions.

## How to Use
### PHP (Laravel) Setup
1. Clone the repository.
2. Navigate to the /Laravel-PHP
3. Install the dependencies:

```shell
composer install
```    

4.Configure your .env file.
5.Run the migrations:
php artisan migrate
```shell
php artisan migrate
```
6.Run the application:
```shell
php artisan serve
```

### C# (.NET) Setup
1. Clone the repository.
2. Navigate to the csharp-dotnet/ directory.
3. Restore the dependencies:
```shell
dotnet restore
```

4.Build and run the application:

```shell
dotnet run
```

## ContributingContributing
If you’d like to contribute to this project, please feel free to submit a pull request or open an issue.
