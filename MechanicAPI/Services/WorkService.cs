using MechanicAPI.Classes;
using MechanicAPI.Interfaces;

namespace MechanicAPI.Services;

public class WorkService(ILogger<WorkService> logger) : IWorkService
{
    private readonly List<Work> worklist =[];
    private readonly ILogger<WorkService> logger;

    public void Add(Work work)
    {
        worklist.Add(work);
        logger.LogInformation($"Adding work {work}");
    }

    public void Update(Work updateWork)
    {
        Work old = worklist.Find(w => w.Id == updateWork.Id);
        
        old.Severity = updateWork.Severity;
        old.ShortDescription = updateWork.ShortDescription;
        old.LicensePlate = updateWork.LicensePlate;
        old.ProductionDate = updateWork.ProductionDate;
        old.WorkCategory = updateWork.WorkCategory;
        logger.LogInformation($"Updating work: from: {old}  to: {updateWork}");
    }

    public void Delete(string id)
    {
        worklist.RemoveAll(w => w.Id == id);
        logger.LogInformation($"Deleting work: {id}");
    }

    public Work Get(string id)
    {
        return worklist.Find(w => w.Id == id);
    }

    public List<Work> GetAll()
    {
        return worklist;
    }
}