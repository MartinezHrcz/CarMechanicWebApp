using MechanicAPI.Classes;
using MechanicAPI.DB;
using MechanicAPI.Interfaces;
using MechanicAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MechanicAPI.Controllers;
[ApiController]
[Route("Client")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public ActionResult<List<Client>> GetAll()
    {
        var clients =  _clientService.GetAll();
        return Ok(clients);
    }

    [HttpPost]
    public ActionResult<Client> Add([FromBody] Client client)
    {
        _clientService.Add(client);
        //_mechanicDataContext.SaveChanges();
        return Ok(_clientService.GetAll().Contains(client));
    }
}