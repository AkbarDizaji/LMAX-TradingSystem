<?php
namespace App\Services;

use App\Models\Trade;
use App\Models\Snapshot;

class TradeProcessorService
{
    protected $currentState = [
        'balance' => 100000, // Example balance for trading
        'positions' => []
    ];

    public function processTrade(Trade $trade)
    {
// In-memory processing of the trade
        if ($trade->type == 'buy') {
            $this->buy($trade);
        } elseif ($trade->type == 'sell') {
            $this->sell($trade);
        }

// Save a snapshot at the end of every day or after a specific number of trades
        $this->saveSnapshot();
    }

    protected function buy(Trade $trade)
    {
        $this->currentState['balance'] -= $trade->price * $trade->quantity;
        $this->currentState['positions'][] = $trade;
    }

    protected function sell(Trade $trade)
    {
        $this->currentState['balance'] += $trade->price * $trade->quantity;
// Logic for selling positions would go here...
    }

    public function saveSnapshot()
    {
        Snapshot::create([
            'state' => json_encode($this->currentState),
        ]);
    }

    public function restoreFromSnapshot()
    {
        $latestSnapshot = Snapshot::latest()->first();
        if ($latestSnapshot) {
            $this->currentState = json_decode($latestSnapshot->state, true);
        }
    }
}
