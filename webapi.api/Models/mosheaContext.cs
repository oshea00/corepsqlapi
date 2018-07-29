using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace webapi.api.Models
{
    public partial class mosheaContext : DbContext
    {
        public mosheaContext()
        {
        }

        public mosheaContext(DbContextOptions<mosheaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Todos> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("todos");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pgcrypto");

            modelBuilder.Entity<Todos>(entity =>
            {
                entity.ToTable("todos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Iscomplete).HasColumnName("iscomplete");
            });
        }
    }
}
