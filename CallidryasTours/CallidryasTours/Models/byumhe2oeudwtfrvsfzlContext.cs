using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CallidryasTours.Models
{
    public partial class byumhe2oeudwtfrvsfzlContext : DbContext
    {
        public byumhe2oeudwtfrvsfzlContext()
        {
        }

        public byumhe2oeudwtfrvsfzlContext(DbContextOptions<byumhe2oeudwtfrvsfzlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Guium> Guia { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<Tour> Tours { get; set; } = null!;
        public virtual DbSet<Ubicacion> Ubicacions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=byumhe2oeudwtfrvsfzl-mysql.services.clever-cloud.com;port=3306;database=byumhe2oeudwtfrvsfzl;uid=ucsztaghg3wxaors;password=1ELJuk2NSIJfSD7d46xm", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Guium>(entity =>
            {
                entity.ToTable("guia");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(255)
                    .HasColumnName("especialidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("pago");

                entity.HasIndex(e => e.ReservaId, "reserva_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaPago).HasColumnName("fecha_pago");

                entity.Property(e => e.Monto)
                    .HasPrecision(10, 2)
                    .HasColumnName("monto");

                entity.Property(e => e.ReservaId).HasColumnName("reserva_id");

                entity.HasOne(d => d.Reserva)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.ReservaId)
                    .HasConstraintName("pago_ibfk_1");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("reserva");

                entity.HasIndex(e => e.ClienteId, "cliente_id");

                entity.HasIndex(e => e.TourId, "tour_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.FechaReserva).HasColumnName("fecha_reserva");

                entity.Property(e => e.TourId).HasColumnName("tour_id");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("reserva_ibfk_1");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.TourId)
                    .HasConstraintName("reserva_ibfk_2");
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.ToTable("tour");

                entity.HasIndex(e => e.GuiaId, "guia_id");

                entity.HasIndex(e => e.UbicacionId, "ubicacion_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.GuiaId).HasColumnName("guia_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasPrecision(10, 2)
                    .HasColumnName("precio");

                entity.Property(e => e.UbicacionId).HasColumnName("ubicacion_id");

                entity.HasOne(d => d.Guia)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.GuiaId)
                    .HasConstraintName("tour_ibfk_2");

                entity.HasOne(d => d.Ubicacion)
                    .WithMany(p => p.Tours)
                    .HasForeignKey(d => d.UbicacionId)
                    .HasConstraintName("tour_ibfk_1");
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.ToTable("ubicacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
