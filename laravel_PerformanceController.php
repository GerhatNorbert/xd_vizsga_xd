<?php

namespace App\Http\Controllers;

use App\Models\Performance;
use Illuminate\Http\Request;

class PerformanceController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return response()->json(Performance::all(), 200, options:JSON_UNESCAPED_UNICODE);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $request->validate([
            "artist_id" => "required|integer|exists:artists,id",
            "act_name" => "required|string|max:100|",
            "duration" => "required|integer"
        ],
        [
            "required" => ":attribute megadása kötelező!",
            "integer" => ":attribute szám tipusu!",
            "string" => ":attribute szöveg tipusu!",
            "exists" => ":attribute nem létezik!",
            "max" => ":attribute maximum :max hossszú lehet!"
        ]);

        Performance::create([
            "artist_id" => $request->artist_id,
            "act_name" => $request->act_name,
            "duration" => $request->duration
        ]);

        return response()->json(["succes" => true, "message" => "Sikeres létrehozás"], 201, options:JSON_UNESCAPED_UNICODE);
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        //
    }
}
