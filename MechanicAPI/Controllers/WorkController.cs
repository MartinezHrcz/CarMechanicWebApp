using MechanicAPI.Classes;
using MechanicAPI.DB;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MechanicAPI.Controllers;

[ApiController]
[Route("Work")]
public class WorkController :ControllerBase
{
    
    private readonly MechanicDataContext _context;
    
    public WorkController(MechanicDataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Work>>> GetAll()
    {
        var works = await _context.Works.ToListAsync();
        return Ok(works);
    }

    [HttpPost]
    public async Task<ActionResult<Work>> Add([FromBody] Work value)
    {
        _context.Works.Add(value);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Work>> Update(int id, [FromBody] Work value)
    {
        if (!value.Id.Equals(id))
        {
            return BadRequest();
        }
        
        var work_OLD= await _context.Works.FindAsync(id);
        
        if (work_OLD is null)
        {
            return NotFound();
        }
        
        work_OLD.WorkCategory = value.WorkCategory;
        work_OLD.ShortDescription = value.ShortDescription;
        work_OLD.LicensePlate = value.LicensePlate;
        work_OLD.ProductionDate = value.ProductionDate;
        work_OLD.Severity = value.Severity;
        
        _context.Works.Update(work_OLD);
        await _context.SaveChangesAsync();
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Work>> Delete(int id)
    {
        var work = await _context.Works.FindAsync(id);
        if (work is null)
        {
            return NotFound();
        }
        _context.Works.Remove(work);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> Get(string id)
    {
        var work = await _context.Works.FindAsync(id);
        if (work is null)
        {
            return NotFound();
        }
        return Ok(work);
        
    }
}