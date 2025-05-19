
using Mechanic.Shared.Modells;
using MechanicAPI.DB;
using MechanicAPI.Services;
using MechanicAPI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace API.tests;

public class WorkServiceTest
{
    private readonly ILogger<WorkService> _mockLoggerW = Substitute.For<ILogger<WorkService>>();
    private MechanicDataContext _context;
    private WorkService _workService;
    //Only for testing 
    private static Client testClient = new Client
    {
        id = 1,
        Name = "Test Client",
        Email = "test@test.com",
        Address = "test street",
    };
    
    public WorkServiceTest()
    {
        var options = new DbContextOptionsBuilder<MechanicDataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _context = new MechanicDataContext(options);
        _workService = new WorkService(_mockLoggerW,_context);
    }

    
    [Fact]
    public async Task AddWorkTest()
    {
        
        //Arrange

        
        Work testWork = 
            new Work{
                Id = 1,
                Client = testClient,
                clientFK =1, 
                LicensePlate = "MSD-711",
                ProductionDate = 2004,
                Progress = ProgressValues.FELVETT_MUNKA,
                ShortDescription = "Test, test",
                Severity = 10,
                WorkCategory = WorkCategories.MOTOR
            };
        //Act
        _context.Clients.Add(testClient);
        
        _workService.Add(testWork);
        await _context.SaveChangesAsync();
        //Assert
        Assert.Equal(testWork, _context.Works.Find(testWork.Id));
    }

    [Fact]
    public async Task UpdateWorkTest()
    {
        int expTotalHours = 12;
        Work testWork = 
            new Work{
                Id = 1,
                Client = testClient,
                clientFK = 1,
                LicensePlate = "MSD-711",
                ProductionDate = 2004,
                Progress = ProgressValues.FELVETT_MUNKA,
                ShortDescription = "Test, test",
                Severity = 10,
                WorkCategory = WorkCategories.KAROSSZÉRIA,
            };
        Work updatedWork = 
            new Work{
                Id = 1,
                Client = testClient,
                clientFK = 1,
                LicensePlate = "MSD-722",
                ProductionDate = 2014,
                Progress = ProgressValues.ELVÉGZÉS_ALATT,
                ShortDescription = "Test, test updated",
                Severity = 10,
                WorkCategory = WorkCategories.MOTOR
            };

        await _workService.Add(testWork);
        await _context.SaveChangesAsync();

        _workService.Update(1, updatedWork);
        await _context.SaveChangesAsync();
        updatedWork.TotalHours = expTotalHours;
        Assert.Equivalent(updatedWork, _context.Works.Find(testWork.Id));
    }

    [Fact]
    public async Task DeleteWorkTest()
    {
        Work testWork = 
            new Work{
                Id = 1,
                Client = testClient,
                clientFK = 1,
                LicensePlate = "MSD-711",
                ProductionDate = 2004,
                Progress = ProgressValues.FELVETT_MUNKA,
                ShortDescription = "Test, test",
                Severity = 10,
                WorkCategory = WorkCategories.KAROSSZÉRIA,
            };
        _workService.Add(testWork);
        await _context.SaveChangesAsync();
        _workService.Delete(1);
        await _context.SaveChangesAsync();
        Assert.False(await _context.Works.AnyAsync(x => x.Id == testWork.Id));
    }

    [Fact]
    public async Task GetWorkTest()
    {
        Work testWork =
            new Work
            {
                Id = 1,
                Client = testClient,
                clientFK = 1,
                LicensePlate = "MSD-711",
                ProductionDate = 2004,
                Progress = ProgressValues.FELVETT_MUNKA,
                ShortDescription = "Test, test",
                Severity = 10,
                WorkCategory = WorkCategories.KAROSSZÉRIA,
            };
        _workService.Add(testWork);
        await _context.SaveChangesAsync();
        var result = await _workService.Get(testWork.Id);
        Assert.Equal(testWork, result);
    }

    [Fact]
    public async Task GetAllWorkTest()
    {
        Work testWork1 = 
            new Work{
                Id = 1,
                Client = testClient,
                clientFK = 1,
                LicensePlate = "MSD-711",
                ProductionDate = 2004,
                Progress = ProgressValues.FELVETT_MUNKA,
                ShortDescription = "Test, test",
                Severity = 10,
                WorkCategory = WorkCategories.KAROSSZÉRIA,
            };
        Work testWork2 = 
            new Work{
                Id = 2,
                Client = testClient,
                clientFK = 1,
                LicensePlate = "MSD-722",
                ProductionDate = 2014,
                Progress = ProgressValues.BEFEJEZETT,
                ShortDescription = "Test, test, test",
                Severity = 4,
                WorkCategory = WorkCategories.FUTÓMŰ,
            };
        _workService.Add(testWork1);
        _workService.Add(testWork2);
        await _context.SaveChangesAsync();
        
        var result = await _workService.GetAll();
        Assert.Equal(new List<Work>{testWork1, testWork2}, result);
    }

    [Theory]
    [InlineData(2014, WorkCategories.MOTOR, 5, 7.2)]
    [InlineData(2020, WorkCategories.FUTÓMŰ, 2, 1.2)]
    public void TotalHoursEstimateTest(int age, WorkCategories category, int severity, double expectedTotalHours)
    {
        Work testWork = 
            new Work{
                Id = 1,
                Client = testClient,
                clientFK = 1,
                LicensePlate = "MSD-711",
                ProductionDate = age,
                Progress = ProgressValues.FELVETT_MUNKA,
                ShortDescription = "Test, test",
                Severity = severity,
                WorkCategory = category
            };
        var result = WorkUtil.CalculateWorkHours(testWork);
        Assert.Equivalent(Math.Round(expectedTotalHours,2), Math.Round(result,2));
    }
}