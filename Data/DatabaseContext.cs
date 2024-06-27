using Fiap.coleta.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.coleta.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<AddressModel> Addresses { get; set; }
        public virtual DbSet<ResidentModel> Residents { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressModel>(entity =>
            {
                entity.ToTable("addresses");
                entity.HasKey(e => e.id);
                entity.Property(e => e.cep).IsRequired();
                entity.Property(e => e.street).IsRequired();
                entity.Property(e => e.neighborhood).IsRequired();
                entity.Property(e => e.number).IsRequired();
                entity.Property(e => e.complement);
                entity.Property(e => e.city).IsRequired();
                entity.Property(e => e.state).IsRequired();
                entity.Property(e => e.created_at).HasColumnType("date");
                entity.Property(e => e.updated_at).HasColumnType("date");

            });

            modelBuilder.Entity<ResidentModel>(entity =>
            {
                entity.ToTable("residents");
                entity.HasKey(e => e.id);
                entity.Property(e => e.name).IsRequired();
                entity.Property(e => e.created_at).HasColumnType("date");
                entity.Property(e => e.updated_at).HasColumnType("date");

                entity.HasOne(e => e.Address).WithMany().HasForeignKey(e => e.address_id).IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
