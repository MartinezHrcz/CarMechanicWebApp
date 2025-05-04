using MechanicAPI.Classes;
using MechanicAPI.DB;
using Microsoft.AspNetCore.Mvc;

namespace MechanicAPI.Controllers;
[ApiController]
[Route("Client")]
public class ClientController : ControllerBase
{
    private readonly MechanicDataContext _mechanicDataContext;

    public ClientController(MechanicDataContext mechanicDataContext)
    {
        _mechanicDataContext = mechanicDataContext;
    }

    [HttpGet]
    public ActionResult<List<Client>> Get()
    {
        var clients =  _mechanicDataContext.Clients;
        return Ok(clients);
    }
}