using MechanicAPI.Classes;
using MechanicAPI.DB;
using MechanicAPI.Interfaces;

namespace MechanicAPI.Services;

public class ClientService(ILogger<ClientService> logger) : IClientService
{
    private readonly ILogger<ClientService> logger;
    private readonly List<Client> clients;

    public void Add(Client client)
    {
        clients.Add(client);
        logger.LogInformation($"Client added: {client}");
    }

    public void Remove(int _id)
    {
        clients.RemoveAll(c => c.id == _id);
        logger.LogInformation($"Client removed: {_id}");
    }

    public void Update(Client updateClient)
    {
        Client old = Get(updateClient.id);
        old.Name = updateClient.Name;
        old.Email = updateClient.Email;
        old.Address = updateClient.Address;
    }

    public Client Get(int _id)
    {
        return clients.Find(c => c.id == _id);
    }

    public List<Client> GetAll()
    {
        return clients;
    }
}