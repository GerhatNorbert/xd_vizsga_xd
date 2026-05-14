<?php

use App\Http\Controllers\ArtistController;
use App\Http\Controllers\PerformanceController;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');


Route::post('/artistak', [ArtistController::class, 'store']);
Route::put('/artistak/{id}/produkcio', [ArtistController::class, 'update']);
Route::get('/artistak', [ArtistController::class, 'index']);

Route::post('/produkciok', [PerformanceController::class, 'store']);
Route::get('/produkciok', [PerformanceController::class, 'index']);
