using Mechanic.Shared.Modells;
using Microsoft.AspNetCore.Mvc;

namespace MechanicAPI.Interfaces;

public interface IClientService
{
    Task<ActionResult<Client>> Add(Client client);
    Task<ActionResult<bool>> Remove(int id);
    Task<bool> Update(int id,Client client);
    Task<Client> Get(int id);
    Task<ActionResult<List<Client>>> GetAll();
}