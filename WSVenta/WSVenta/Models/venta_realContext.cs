using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSVenta.Models
{
    public partial class venta_realContext : DbContext
    {
        public venta_realContext()
        {
        }

        public venta_realContext(DbContextOptions<venta_realContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Concepto> Conceptos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=venta_real;uid=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.6.51-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.ToTable("concepto");

                entity.HasIndex(e => e.IdProducto, "id_producto_idx");

                entity.HasIndex(e => e.IdVenta, "id_venta_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int(11)")
                    .HasColumnName("cantidad");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id_producto");

                entity.Property(e => e.IdVenta)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id_venta");

                entity.Property(e => e.Importe)
                    .HasPrecision(16, 2)
                    .HasColumnName("importe");

                entity.Property(e => e.PrecioUnitario)
                    .HasPrecision(16, 2)
                    .HasColumnName("precioUnitario");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Conceptos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_producto");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Conceptos)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_venta");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Costo)
                    .HasPrecision(16, 2)
                    .HasColumnName("costo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrecioUnitario)
                    .HasPrecision(16, 2)
                    .HasColumnName("precioUnitario");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.ToTable("venta");

                entity.HasIndex(e => e.IdCliente, "id_cliente_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCliente)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id_cliente");

                entity.Property(e => e.Total)
                    .HasPrecision(16, 2)
                    .HasColumnName("total");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_cliente");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
