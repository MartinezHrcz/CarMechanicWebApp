using Mechanic.Shared.Modells;

namespace WebASM.Services;

public interface IWorkService
{
    Task<List<Work>> GetWorksAsync();
    Task<Work> GetWorkByIdAsync(int id);
    Task AddWorkAsync(Work work);
    Task UpdateWorkAsync(int id,Work work);
    Task DeleteWorkAsync(int id);
}