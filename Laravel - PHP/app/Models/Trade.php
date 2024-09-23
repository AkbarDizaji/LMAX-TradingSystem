<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Trade extends Model
{
    use HasFactory;
    protected $fillable = [
        'type',      // type of trade: buy/sell
        'quantity',  // trade quantity
        'price',     // price of the trade
    ];
}
