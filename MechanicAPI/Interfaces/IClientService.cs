using MechanicAPI.Classes;

namespace MechanicAPI.Interfaces;

public interface IClientService
{
    void Add(Client client);
    void Remove(int id);
    void Update(Client client);
    Client Get(int id);
    List<Client> GetAll();
}