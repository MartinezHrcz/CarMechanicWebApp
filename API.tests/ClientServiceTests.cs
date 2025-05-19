using Mechanic.Shared.Modells;
using MechanicAPI.DB;
using MechanicAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace API.tests;

public class ClientServiceTests
{
    private readonly ILogger<ClientService> _mockLoggerC = Substitute.For<ILogger<ClientService>>();
    private MechanicDataContext _context;
    private ClientService _clientService;
    private static Client testClient = new Client
    {
        id = 1,
        Name = "TEST",
        Email = "test@test.com",
        Address = "test street address"
    };
    
    public ClientServiceTests()
    {
        var options = new DbContextOptionsBuilder<MechanicDataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _context = new MechanicDataContext(options);
        _clientService = new ClientService(_mockLoggerC,_context);
    }
    [Fact]
    public async Task AddClient()
    {
        await _clientService.Add(testClient);
        await _context.SaveChangesAsync();
        Assert.Equal(testClient, await _context.Clients.FindAsync(testClient.id));
    }
    [Fact]
    public async Task DeleteClient()
    {
        await _context.Clients.AddAsync(testClient);
        await _context.SaveChangesAsync();
        _clientService.Remove(testClient.id);
        await _context.SaveChangesAsync();
        Assert.Null(await _context.Clients.FindAsync(testClient.id));
    }
    [Fact]
    public async Task UpdateClient()
    {
        Client updateClient = new  Client
        {
            Name = "Test 2",
            Email = "test2@gmail.com",
            Address = "test street address"
        };
        
        await _clientService.Add(testClient);
        int updateID = testClient.id;

        await _clientService.Update(updateID, updateClient);
        await _context.SaveChangesAsync();
        var result = await _clientService.Get(testClient.id);
        Assert.Equal(updateClient.Name, result.Name);
        Assert.Equal(updateClient.Email, result.Email);
        Assert.Equal(updateClient.Address, result.Address);
    }
    [Fact]
    public async Task GetClients()
    {
        Client c1 = new  Client
        {
            Name = "Test 1",
            Email = "test1@test.com",
            Address = "test1 street address"
        };

        Client c2 = new  Client
        {
            Name = "Test 2",
            Email = "test2@test.com",
            Address = "test2 street address"
        };
        
        await _clientService.Add(c1);
        await _clientService.Add(c2);
        await _context.SaveChangesAsync();
        List<Client> clients = await _context.Clients.ToListAsync();
        Assert.Equal(c1, clients[0]);
        Assert.Equal(c2, clients[1]);

    }
    [Fact]
    public async Task GetClientById()
    {
        _clientService.Add(testClient);
        await _context.SaveChangesAsync();
        Assert.Equal(testClient, await _context.Clients.FindAsync(testClient.id));
    }

}