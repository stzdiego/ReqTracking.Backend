using Microsoft.EntityFrameworkCore;
using ReqTracking.Backend.Models;

namespace ReqTracking.Backend.Context;

public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Requeriment> Requeriments { get; set; }
    public DbSet<Tracking> Trackings { get; set; }
    public DbSet<UserLead> UsersLeads { get; set; }
    
    private IConfiguration Configuration { get; } = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    }
}