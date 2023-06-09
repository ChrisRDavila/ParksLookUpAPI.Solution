using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookUpAPI.Models;
using System;

namespace ParksLookUpAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksLookUpAPIContext _db;

    public ParksController(ParksLookUpAPIContext db)
    {
      _db = db;
    }

    // GET api/parks
    [HttpGet]
    public async Task<List<Park>> Get(string name, string state, string features, int minRating)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }

      if (features != null)
      {
        query = query.Where(entry => entry.Features == features);
      }

      if (minRating > 0)
      {
        query = query.Where(entry => entry.Rating >= minRating);
      }

      return await query.ToListAsync();
    }

    // GET: api/Parks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);

      if (park == null)
      {
        return NotFound();
      }

      return park;
    }

    // POST api/Parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }
  }
}    
