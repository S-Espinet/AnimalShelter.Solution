using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    //Get api/animals
    /// <summary>
    /// Gets multiple destinations, can be sorted
    /// </summary>
    /// <remarks>
    /// Get all reviews:
    ///
    ///     GET /Destinations
    ///     {
    ///     }
    ///
    /// Sort by Type:
    ///
    ///     GET /animals?sortMethod=type
    ///     {
    ///     }
    ///
    /// Sort by Gender:
    ///
    ///     GET /animals?sortMethod=gender
    ///     {
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="sortMethod">Either blank, type, or gender</param>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get(string sortMethod)
    {
      var query = _db.Animals.AsQueryable();
      if (sortMethod == "type")
      {
        query = _db.Animals.OrderBy(animal => animal.Type);
      }
      else if (sortMethod == "gender")
      {
        query = _db.Animals.OrderBy(animal => animal.Gender);
      }
      else
      {
        query = _db.Animals.OrderBy(animal => animal.Age);
      }
      return await query.ToListAsync();
    }

    // POST api/animals
    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = animal.AnimalId }, animal);
    }

    // Get api/animals/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }
      return animal;
    }

    // PUT: api/Animals/id
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }

      _db.Entry(animal).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
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

    // DELETE: api/Animals/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }
  }
}