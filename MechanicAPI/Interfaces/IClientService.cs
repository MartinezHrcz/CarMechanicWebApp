using MechanicAPI.Classes;

namespace MechanicAPI.Interfaces;

public interface IClientService
{
    void Add(Client client);
    void Remove(string id);
    void Update(Client client);
    Client Get(string id);
    List<Client> GetAll();
}