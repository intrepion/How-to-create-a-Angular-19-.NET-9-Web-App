using Microsoft.EntityFrameworkCore;

namespace YoutubeDotNet9.Models
{
    public partial class SampleDatabaseContext : DbContext
    {
        public SampleDatabaseContext()
        {

        }

        public SampleDatabaseContext(DbContextOptions<SampleDatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<Pokemon> Pokemons { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.ToTable("Pokemon");

                entity.Property(x => x.Name).HasMaxLength(50);

                entity.HasOne(x => x.Region).WithMany(x => x.Pokemons)
                    .HasForeignKey(x => x.RegionId)
                    .HasConstraintName("FK_Pokemon_Region");

                entity.HasOne(x => x.Type).WithMany(x => x.Pokemons)
                    .HasForeignKey(x => x.TypeId)
                    .HasConstraintName("FK_Pokemon_Type");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(x => x.RegionName).HasMaxLength(50);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(x => x.Name).HasMaxLength(50);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
