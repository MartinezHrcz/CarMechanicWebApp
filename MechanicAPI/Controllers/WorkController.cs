using MechanicAPI.Classes;
using MechanicAPI.DB;
using MechanicAPI.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MechanicAPI.Controllers;

[ApiController]
[Route("Work")]
public class WorkController :ControllerBase
{
    
    private readonly IWorkService _workService;
    
    public WorkController(IWorkService workService)
    {
        _workService = workService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Work>>> GetAll()
    {
        var works = await _workService.GetAll();
        return Ok(works);
    }

    [HttpPost]
    public async Task<ActionResult<Work>> Add([FromBody] Work value)
    {
        await _workService.Add(value);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Work>> Update(int id, [FromBody] Work value)
    {
        var result = await _workService.Update(id, value);
        if (!value.Id.Equals(id))
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Work>> Delete(int id)
    {
        if(_workService.Get(id).Equals(null))
        {
            return NotFound();
        }
        var work = await _workService.Delete(id);
        
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Work>> Get(int id)
    {
        var work = await _workService.Get(id);
        return Ok(work);

    }

    [HttpPost("{id}")]
    public async Task<ActionResult<double>> TotalWorkHours(int id)
    {
        var result = await _workService.GetTotalWorkHours(id);
        return Ok(result);
    }
}