<?php

namespace App\Http\Controllers;

use App\Jobs\ProcessTrade;
use App\Models\Trade;
use Illuminate\Http\Request;

class TradeController extends Controller
{
    public function placeTrade(Request $request)
    {
        // Validate the request data
        $validatedData = $request->validate([
            'type' => 'required|string',       // 'buy' or 'sell'
            'quantity' => 'required|integer',
            'price' => 'required|numeric',
        ]);

        // Create the trade (this will use the create() method)
        $trade = Trade::create($validatedData);

        // Dispatch the trade for processing
        ProcessTrade::dispatch($trade);

        return response()->json(['message' => 'Trade placed and queued for processing']);
    }
}
