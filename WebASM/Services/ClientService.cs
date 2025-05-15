using System.Net.Http.Json;
using Mechanic.Shared.Modells;

namespace WebASM.Services;

public class ClientService : IClientService
{
    HttpClient _httpClient;

    public ClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Client>> GetClientsAsync()
    {
        return (await _httpClient.GetFromJsonAsync<List<Client>>("client"))!;
    }

    public async Task<Client> GetClientByIdAsync(int id)
    {
        return (await _httpClient.GetFromJsonAsync<Client>($"client/{id}") )!;
    }

    public async Task AddClientAsync(Client client)
    {
        await _httpClient.PostAsJsonAsync<Client>("client", client);
    }

    public async Task UpdateClientAsync(int id, Client client)
    {
        await _httpClient.PutAsJsonAsync($"client/{id}", client); 
    }

    public async Task DeleteClientAsync(int id)
    {
        await _httpClient.DeleteAsync($"client/{id}");
    }
}