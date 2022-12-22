using System;
using Microsoft.AspNetCore.Mvc;
using grupp5.Services;
using grupp5.Models;

namespace grupp5.Controllers;

[Controller]
[Route("api/[controller]")]
public class TripController : Controller {


    private readonly TripService _tripService;

    public TripController(TripService tripService)
    {
        _tripService = tripService;

    }

    [HttpGet]
    public async Task<List<Trip>> GetTrip()
    {
        return await _tripService.GetTrip();
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Trip trip)
    {
        await _tripService.CreateTrip(trip);
        return CreatedAtAction(nameof(Post), new { id = trip.Id }, trip);
    }
/*
    [HttpPut("{id}")]
    public async Task<IActionResult> AddToTrip(string id, [FromBody] string src_airport)
    {
        await _tripService.AddToTripAsync(id, src_airport);
        return NoContent();
    }
    */

    
    [HttpPut("{id}")]
    public async Task<IActionResult> AddToTrip(string id, [FromBody] Trip trip)
    {
    
        trip.Id = id;

        await _tripService.UpdateTrip(id, trip);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _tripService.DeleteTripAsync(id);
        return NoContent();
    }

}