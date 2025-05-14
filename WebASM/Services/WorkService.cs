using System.Net.Http.Json;
using Mechanic.Shared.Modells;

namespace WebASM.Services;

public class WorkService: IWorkService
{
    private readonly HttpClient _httpClient;

    public WorkService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Work>> GetWorksAsync()
    {
        return (await _httpClient.GetFromJsonAsync<List<Work>>("work"))!;
    }

    public async Task<Work> GetWorkByIdAsync(int id)
    {
        return (await _httpClient.GetFromJsonAsync<Work>($"work/{id}"))!;
    }

    public async Task AddWorkAsync(Work work)
    {
        await _httpClient.PostAsJsonAsync("work", work);
    }

    public async Task UpdateWorkAsync(int id, Work work)
    {
        await _httpClient.PutAsJsonAsync($"work/{id}", work);
    }

    public async Task DeleteWorkAsync(int id)
    {
        await _httpClient.DeleteAsync($"work/{id}");
    }
}