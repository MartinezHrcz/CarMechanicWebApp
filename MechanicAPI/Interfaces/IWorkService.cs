using MechanicAPI.Classes;
using Microsoft.AspNetCore.Mvc;

namespace MechanicAPI.Interfaces;

public interface IWorkService
{
    Task<ActionResult<Work>> Add(Work work);
    Task<bool> Update(int id, Work work);
    Task<ActionResult<bool>> Delete(int id);
    Task<Work> Get(int id);
    Task<ActionResult<List<Work>>> GetAll();
    Task<ActionResult<double>> GetTotalWorkHours(int id);
}