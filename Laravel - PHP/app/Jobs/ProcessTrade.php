<?php

namespace App\Jobs;

use App\Models\Trade;
use App\Services\TradeProcessorService;
use Illuminate\Contracts\Queue\ShouldQueue;
use Illuminate\Foundation\Bus\Dispatchable;
use Illuminate\Foundation\Queue\Queueable;
use Illuminate\Queue\InteractsWithQueue;
use Illuminate\Queue\SerializesModels;

class ProcessTrade implements ShouldQueue
{
    protected $trade;

    use Queueable;

    /**
     * Create a new job instance.
     */
    public function __construct(Trade $trade)
    {
        $this->trade = $trade;
    }

    /**
     * Execute the job.
     */
    public function handle(TradeProcessorService $tradeProcessor): void
    {
        $tradeProcessor->processTrade($this->trade);
    }
}
