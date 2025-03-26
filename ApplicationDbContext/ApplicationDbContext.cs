using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Drawing;

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
        modelBuilder.Entity<Rating.Rating>()
            .HasIndex(c => new { c.UserId, c.ContentId })
            .IsUnique(true);

        modelBuilder.Entity<Rating.Rating>()
            .HasOne(x => x.Content)
            .WithMany()
            .HasForeignKey(x => x.ContentId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
