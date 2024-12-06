using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationKhasanovUP.Models;

[Route("api/[controller]")]
[ApiController]
public class AddController : ControllerBase
{
    private readonly UpkhasanovContext _context;

    public AddController(UpkhasanovContext context)
    {
        _context = context;
    }

    // GET: api/adds
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Add>>> GetAll()
    {
        return await _context.Adds.ToListAsync();
    }

    // GET: api/adds/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Add>> GetById(int id)
    {
        var add = await _context.Adds.FindAsync(id);
        if (add is null)
            return NotFound();

        return add;
    }

    // POST: api/adds
    [HttpPost]
    public async Task<IActionResult> Create(Add add)
    {
        _context.Adds.Add(add);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = add.AddId }, add);
    }
    // PUT: api/adds/5
    // The method below will handle the PUT requests
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAdd(int id, Add add)
    {
        if (id != add.AddId)
        {
            return BadRequest();
        }

        _context.Entry(add).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AddExists(id))
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

    private bool AddExists(int id)
    {
        return _context.Adds.Any(e => e.AddId == id);
    }
    // DELETE: api/adds/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdd(int id)
    {
        var add = await _context.Adds.FindAsync(id);
        if (add == null)
        {
            return NotFound();
        }

        _context.Adds.Remove(add);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
