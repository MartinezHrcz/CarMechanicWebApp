using MechanicAPI.Classes;
using Microsoft.EntityFrameworkCore;

namespace MechanicAPI.DB;

public class MechanicDataContext : DbContext
{
    public MechanicDataContext(DbContextOptions options):base(options)
    {
    }
    
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Work> Works { get; set; }
}