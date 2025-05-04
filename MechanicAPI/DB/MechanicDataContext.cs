using MechanicAPI.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace MechanicAPI.DB;

public class MechanicDataContext : DbContext
{

    public MechanicDataContext(DbContextOptions options)
        :base(options)
    {
    }
    
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Work> Works { get; set; }


}