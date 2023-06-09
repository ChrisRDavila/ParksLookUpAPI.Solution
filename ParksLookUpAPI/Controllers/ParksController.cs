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
    public async Task<List<Park>> Get(string name, string state, string features, int minimum_rating)
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

      if (minimum_rating > 0)
      {
        query = query.Where(entry => entry.Rating >= minimum_rating);
      }

      return await query.ToListAsync();
    }

    // GET: api/Parks
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

    // GET: api/Parks/page
    [HttpGet("page/{page}")]
    public async Task<ActionResult<List<Park>>> GetPages(int page, int pageSize)
    {
        if (_db.Parks == null)
        return NotFound();

      int pageCount = _db.Parks.Count();
      pageSize = 2;

      var parks = await _db.Parks
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

        var response = new Pagination
      {
        Parks = parks,
        PageItems = pageCount,
        CurrentPage = page,
        PageSize = pageSize
      };
      return Ok(response);
    }

    // POST api/Parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

        // PUT: api/Animals
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Parks.Update(park);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    // Verify enrty in db for PUT
    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }

    // DELETE: api/Parks
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    
  }
}  
