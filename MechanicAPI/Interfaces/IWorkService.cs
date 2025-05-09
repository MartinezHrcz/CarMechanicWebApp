using MechanicAPI.Classes;

namespace MechanicAPI.Interfaces;

public interface IWorkService
{
    void Add(Work work);
    void Update(Work work);
    void Delete(int id);
    Work Get(int id);
    List<Work> GetAll();
}