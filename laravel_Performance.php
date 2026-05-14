<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Performance extends Model
{
    protected $fillable = [
        "artist_id",
        "act_name",
        "duration"
    ];

    public function Artist(){
        return $this->belongsTo(Artist::class);
    }
}
