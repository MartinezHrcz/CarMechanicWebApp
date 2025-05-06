using MechanicAPI.Classes;
using MechanicAPI.Interfaces;

namespace MechanicAPI.Services;

public class ClientService(ILogger<ClientService> logger) : IClientService
{
    private readonly List<Client> clients = [];

    /**
     * Todo:
     * -change this to data base context !!!!!!!
     */
    
    public void Add(Client client)
    {
        clients.Add(client);
        logger.LogInformation($"Client added: {client}");
    }

    public void Remove(string id)
    {
        clients.RemoveAll(c => c.Id == id);
        logger.LogInformation($"Client removed: {id}");
    }

    public void Update(Client updateClient)
    {
        Client old = Get(updateClient.Id);
        old.Name = updateClient.Name;
        old.Email = updateClient.Email;
        old.Address = updateClient.Address;
    }

    public Client Get(string id)
    {
        return clients.Find(c => c.Id == id);
    }

    public List<Client> GetAll()
    {
        return clients;
    }
}