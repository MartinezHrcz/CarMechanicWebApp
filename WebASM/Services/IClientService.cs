using Mechanic.Shared.Modells;

namespace WebASM.Services;

public interface IClientService
{
    Task<List<Client>> GetClientsAsync();
    Task<Client> GetClientByIdAsync(int id);
    Task AddClientAsync(Client client);
    Task UpdateClientAsync(int id,Client client);
    Task DeleteClientAsync(int id);
}