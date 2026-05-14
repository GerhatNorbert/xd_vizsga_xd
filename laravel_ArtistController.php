<?php

namespace App\Http\Controllers;

use App\Models\Artist;
use Illuminate\Http\Request;
use PHPUnit\Event\Test\Failed;

class ArtistController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return response()->json(Artist::all(), 200, options:JSON_UNESCAPED_UNICODE);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
         $request->validate([
            "name" => "required|string",
            "specialty" => "required|string|max:100",
            "is_ready" => "integer"
        ],
        [
            "required" => ":attribution megadása kötelező!",
            "integer" => ":attribute szám tipusu!",
            "string" => ":attribute szöveg tipusu!",
            //"exists" => ":attribute nem létezik!",
            "max" => ":attribute maximum :max hossszú lehet!"
        ]);

        Artist::create([
            "name" => $request->name,
            "specialty" => $request->specialty,
            "is_ready" => 1
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
        $artist = Artist::find($id);
        if (!$artist)
            {
                return response()->json(["success" => false, "message" => "Nincs iylen ID előadó"], 404, options:JSON_UNESCAPED_UNICODE);
            }
        $artist->is_ready = 0;
        $artist->save();

        return response()->json(["success" => true, "message" => "Sikeres átállítás"], 200, options:JSON_UNESCAPED_UNICODE);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        //
    }
}
