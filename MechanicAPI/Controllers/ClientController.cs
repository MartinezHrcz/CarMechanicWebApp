using MechanicAPI.Classes;
using MechanicAPI.DB;
using MechanicAPI.Interfaces;
using MechanicAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MechanicAPI.Controllers;
[ApiController]
[Route("Client")]
public class ClientController : ControllerBase
{
    private readonly MechanicDataContext _context;
    public ClientController(MechanicDataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Client>>> GetAll()
    {
        var clients = await _context.Clients.ToListAsync();
        return Ok(clients);
    }

    [HttpPost]
    public async Task<ActionResult<Client>> Add([FromBody] Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Client>> Update(string id, [FromBody] Client client)
    {
        if (!client.id.Equals(id))
        {
            return BadRequest();
        }
        
        var client_OLD= await _context.Clients.FindAsync(id);
        
        if (client_OLD is null)
        {
            return NotFound();
        }
        
        client_OLD.Name = client.Name;
        client_OLD.Email = client.Email;
        client_OLD.Address = client.Address;
        
        _context.Clients.Update(client_OLD);
        await _context.SaveChangesAsync();
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Client>> Delete(string id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client is null)
        {
            return NotFound();
        }
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> Get(string id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client is null)
        {
            return NotFound();
        }
        return Ok(client);
        
    }

}