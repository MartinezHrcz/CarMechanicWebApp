using Mechanic.Shared.Modells;
using MechanicAPI.DB;
using MechanicAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MechanicAPI.Services;

public class ClientService : IClientService
{
    private readonly ILogger<ClientService> logger;
    private readonly MechanicDataContext _context;

    public ClientService(ILogger<ClientService> logger, MechanicDataContext context)
    {
        this.logger = logger;
        _context = context;
    }

    public async Task<ActionResult<Client>> Add(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        logger.LogInformation($"Client added: {client}");
        return client;
    }

    public async Task<ActionResult<bool>> Remove(int _id)
    {
        var client = await _context.Clients.FindAsync(_id);
        if (client is null)
        {
            return false;
        }
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        logger.LogInformation($"Client removed: {_id}");
        return true;
    }

    public async Task<bool> Update(int _id,Client updateClient)
    {
        var old = await _context.Clients.FindAsync(_id);
        if (old is null)
        {
            return false;
        }
        
        old.Name = updateClient.Name;
        old.Email = updateClient.Email;
        old.Address = updateClient.Address;
        await _context.SaveChangesAsync();
        logger.LogInformation($"Client updated: {updateClient}");
        return true;
    }

    public async Task<Client> Get(int _id)
    {
        return (await _context.Clients.FindAsync(_id))!;
    }

    public async Task<ActionResult<List<Client>>> GetAll()
    {
        var clients = await _context.Clients.ToListAsync();
        return clients;
    }
}