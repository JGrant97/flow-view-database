using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace flow_view_database.ApplicationDbContext;
public class ApplicationDbContext : 
    IdentityDbContext<ApplicationUser.ApplicationUser, ApplicationRole.ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Content.Content> Content { get; set; }
    public DbSet<Rating.Rating> Rating { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
