using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookUpAPI.Models;
using System;

namespace ParksLookUpAPI.Controllers
{
  [ApiController]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiVersion("2.0")]
  public class ParksController : ControllerBase
  {
    private readonly ParksLookUpAPIContext _db;

    public ParksController(ParksLookUpAPIContext db)
    {
      _db = db;
    }

      // GET: api/v2/travels
    [HttpGet]
    public async Task<IActionResult>  Get(string name, string state, string features, int filterRating, int? page)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();

      if (name != null)
      {
        query = query.Where(e => e.Name == name);
      }

      if (state != null)
      {
        query = query.Where(e => e.State == state);
      }

      if (features != null)
      {
        query = query.Where(e => e.Features == features);
      }

      if (filterRating > 0)
      {
        query = query.Where(entry => entry.Rating >= filterRating);
      }

      int pageCount = query.Count();
      int pageSize = 2;
      int currentPage = page ?? 1;

      var parks = await query
        .Skip((currentPage - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

      var response = new Pagination
      {
        Parks = parks,
        PageItems  = pageCount,
        CurrentPage = currentPage,
        PageSize = pageSize         
      };

      return Ok(response);      
    }

    // GET: api/v2/Parks/{id}
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

    // GET: api/v2/Parks/page
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

    // GET: api/v2/parks/random
    [HttpGet("random")]
    public async Task<ActionResult<Park>> GetRandomPark()
    {
      List<Park> parks = await _db.Parks.ToListAsync();
      int randomPark = new Random().Next(parks.Count);
      return parks[randomPark];
    }

    // POST api/v2/Parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

        // PUT: api/v2/Animals/{id}
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

    // DELETE: api/v2/Parks/{id}
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
