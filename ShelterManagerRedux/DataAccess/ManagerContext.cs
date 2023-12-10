using Microsoft.EntityFrameworkCore;

public class ManagerContext : DbContext
{
    public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}

