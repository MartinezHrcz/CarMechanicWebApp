using Mechanic.Shared.Modells;
using Microsoft.AspNetCore.Mvc;

namespace MechanicAPI.Interfaces;

public interface IWorkService
{
    Task<ActionResult<Work>> Add(Work work);
    Task<bool> Update(int id, Work work);
    Task<ActionResult<bool>> Delete(int id);
    Task<Work> Get(int id);
    Task<List<Work>> GetAll();
    Task<double> GetTotalWorkHours(int id);
}