using Mechanic.Shared.Modells;
using MechanicAPI.DB;
using MechanicAPI.Interfaces;
using MechanicAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace MechanicAPI.Services;

public class WorkService : IWorkService
{
    private readonly ILogger<IWorkService> _logger;
    private readonly MechanicDataContext _context;

    public WorkService(ILogger<IWorkService> logger, MechanicDataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<ActionResult<Work>> Add(Work work)
    {
        work.TotalHours = WorkUtil.CalculateWorkHours(work);
        _context.Works.Add(work);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Work added {work}");
        return work;
    }

    public async Task<bool> Update(int id, Work updateWork)
    {
        var old = await _context.Works.FindAsync(id);
        
        if (old is null)
        {
            return false;
        }

        old.Severity = updateWork.Severity;
        old.ShortDescription = updateWork.ShortDescription;
        old.LicensePlate = updateWork.LicensePlate;
        old.ProductionDate = updateWork.ProductionDate;
        old.WorkCategory = updateWork.WorkCategory;
        old.TotalHours = WorkUtil.CalculateWorkHours(updateWork);
        if ((int)old.Progress <= (int) updateWork.Progress)
        {
            old.Progress = updateWork.Progress;
        } 
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Updating work: from: {old}  to: {updateWork}");
        return true;
    }

    public async Task<ActionResult<bool>> Delete(int id)
    {
        var work = await _context.Works.FindAsync(id);
        if (work is null)
        {
            return false;
        }
        _context.Works.Remove(work);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Work deleted {work}");
        return true;
    }

    public async Task<Work> Get(int id)
    {
        return (await _context.Works.FindAsync(id))!;
        
    }

    public async Task<List<Work>> GetAll()
    {
        return await _context.Works.ToListAsync();
    }

    public async Task<double> GetTotalWorkHours(int id)
    {
        var work = await _context.Works.FindAsync(id);
        return 0;
    }
}