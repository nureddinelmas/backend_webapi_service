using System;
using Microsoft.AspNetCore.Mvc;
using grupp5.Services;
using grupp5.Models;

namespace grupp5.Controllers;

[Controller]
[Route("api/[controller]")]
public class TripController : Controller
{


    private readonly TripService _tripService;

    public TripController(TripService tripService)
    {
        _tripService = tripService;

    }


    /// <summary>
    /// get all trips.
    /// </summary>
    /// By this function we get all items from database we have.
    [HttpGet]
    public async Task<List<Trip>> GetTrip()
    {
        return await _tripService.GetTrip();
    }


    /// <summary>
    /// Add a trip by posting
    /// </summary>
    /// By this function we create one new trip item. This trip that we gonna create comes from body in Swagger UI or by coding.
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Trip trip)
    {
        await _tripService.CreateTrip(trip);
        return CreatedAtAction(nameof(Post), new { id = trip.Id }, trip);
    }


    /// <summary>
    /// Get specific trip by Id
    /// </summary>
    /// Here we can get one item by id from database. We use here async when getting database. We enter id and return one trip item
    [HttpGet("{id}")]
    public async Task<ActionResult<Trip>> Get(string id)
    {
        var trip = await _tripService.GetAsync(id);

        if (trip is null)
        {
            return NotFound();
        }

        return trip;
    }

    /// <summary>
    /// Change a trip's item by id.
    /// </summary>
    /// By this function we can change one item's we have in database.
    [HttpPut("{id}")]
    public async Task<IActionResult> AddToTrip(string id, [FromBody] Trip trip)
    {

        trip.Id = id;

        await _tripService.UpdateTrip(id, trip);
        return NoContent();
    }


    /// <summary>
    /// Delete a trip by trip id.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _tripService.DeleteTripAsync(id);
        return NoContent();
    }

}
