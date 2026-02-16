using Microsoft.EntityFrameworkCore;
using Competition.API.Modules.Tournments;
using Competition.API.Modules.Teams;
using Competition.API.Modules.Squads;

public class CompetitionDbContext : DbContext
{
    public CompetitionDbContext(DbContextOptions<CompetitionDbContext> options) : base(options) { }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Squad> Squads { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(256);
            entity.HasIndex(e => new { e.Name, e.CreatedByUserId }).IsUnique();
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(256);
            entity.Property(e => e.ShortName).HasMaxLength(50);
            entity.HasOne<Tournament>()
                .WithMany()
                .HasForeignKey(e => e.TournamentId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Squad>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Status).IsRequired();
            entity.HasOne<Team>()
                .WithMany()
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(e => e.Players)
                .WithOne()
                .HasForeignKey(p => p.SquadId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<SquadPlayer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PlayerName).IsRequired().HasMaxLength(256);
            entity.Property(e => e.Role).IsRequired();
        });
    }
}