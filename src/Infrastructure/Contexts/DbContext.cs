using BunkerWebServer.Infrastructure.Data.Entities.Rooms;
using BunkerWebServer.Infrastructure.Data.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace BunkerWebServer.Infrastructure.Contexts
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<UserData> Users { get; set; }
        public DbSet<RoomData> Rooms { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
        : base(contextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>()
                .HasMany(s => s.Rooms)
                .WithMany(s => s.Users)
                .UsingEntity<RoomMember>(
                    j => j.HasOne(r => r.Room)
                        .WithMany()
                        .HasForeignKey(e => e.RoomId),
                    j => j.HasOne(r => r.User)
                        .WithMany()
                        .HasForeignKey(r => r.UserId),
                    j => j.ToTable("RoomMembers")
                    .HasKey(r => r.Id));
        }
    }
}
