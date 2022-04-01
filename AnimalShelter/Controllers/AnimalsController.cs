using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
#pragma warning disable CS1591
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }
#pragma warning restore CS1591

    //Get api/animals
    /// <summary>
    /// Gets all animals, can be sorted
    /// </summary>
    /// <remarks>
    /// Get all animals:
    ///
    ///     GET /animals
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
    /// <summary>
    /// Creates new animal
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Post /animals
    ///     {
    ///       "Type": "Type of Animal; Cat or Dog",
    ///       "Name": "Name of Animal",
    ///       "Age": Integer,
    ///       "Gender": "Female or Male"
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="animal">An Animal</param>
    /// <response code="201">Returns a newly created animal.</response>
    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = animal.AnimalId }, animal);
    }

    // Get api/animals/id
    /// <summary>
    /// Retrieve animal based on ID
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /animal/2
    ///     {
    ///     }
    ///
    /// </remarks>
    ///
    /// <param name="id">Animal Id</param>
    /// <response code="404">No animal with that Id exists.</response>

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

    // PUT: api/animals/id
    /// <summary>
    /// Edits an animal
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Put /animals/id
    ///     {
    ///       "Type": "Updated Type of Animal; Cat or Dog",
    ///       "Name": "Updated Animal Name",
    ///       "Age": Updated Integer,
    ///       "Gender": "Updated Gender",
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="id"></param>
    /// <param name="animal"></param>
    /// <response code="204">Updates Animal</response>
    /// <response code="400">Animal ID doesn't match ID that is passed.</response>
    
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

    // DELETE: api/animals/id
    /// <summary>
    /// Removes an animal
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Delete /animals/id
    ///     {
    ///     }
    ///
    ///
    /// </remarks>
    ///
    /// <param name="id"></param>
    /// <response code="204">Removes animal</response>
    /// <response code="404">Animal ID doesn't exist.</response>
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