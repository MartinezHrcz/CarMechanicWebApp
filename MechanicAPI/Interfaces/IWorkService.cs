using MechanicAPI.Classes;

namespace MechanicAPI.Interfaces;

public interface IWorkService
{
    void Add(Work work);
    void Update(Work work);
    void Delete(string id);
    Work Get(string id);
    List<Work> GetAll();
}