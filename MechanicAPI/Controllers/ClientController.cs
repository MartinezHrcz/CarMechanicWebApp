using Mechanic.Shared.Modells;
using MechanicAPI.DB;
using MechanicAPI.Interfaces;
using MechanicAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace MechanicAPI.Controllers;
[ApiController]
[Route("Client")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    public ClientController(IClientService clientService)
    {
        _clientService = clientService ;
    }

    [HttpGet]
    public async Task<ActionResult<List<Client>>> GetAll()
    {
        var clients = await _clientService.GetAll();
        clients.Value.ForEach(c=>Console.WriteLine(c.id));
        return clients;
    }

    [HttpPost]
    public async Task<ActionResult<Client>> Add([FromBody] Client client)
    {
        await _clientService.Add(client);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Client>> Update(int id, [FromBody] Client client)
    {
        bool result = await _clientService.Update(id, client);
        if (!result)
        {
            return BadRequest();
        }
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Client>> Delete(int id)
    {
        var client = await _clientService.Get(id);
        if (client.Equals(null))
        {
            return NotFound();
        }
        await _clientService.Remove(id);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> Get(int id)
    {
        var client = _clientService.Get(id);
        return Ok(client);
        
    }

}