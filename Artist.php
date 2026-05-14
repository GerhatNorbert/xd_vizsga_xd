<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use League\MimeTypeDetection\FinfoMimeTypeDetector;

class Artist extends Model
{
    protected $fillable = [
        "name",
        "specialty",
        "is_ready"
    ];

    public function Performances(){
        return $this->hasMany(Performance::class);
    }
}
