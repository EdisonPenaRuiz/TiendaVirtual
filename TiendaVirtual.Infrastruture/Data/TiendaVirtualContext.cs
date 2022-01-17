using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TiendaVirtual.Core.Entities;

namespace TiendaVirtual.Infrastruture.Data
{
    public partial class TiendaVirtualContext : DbContext
    {
        public TiendaVirtualContext()
        {
        }

        public TiendaVirtualContext(DbContextOptions<TiendaVirtualContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<Cuenta> Cuentas { get; set; } = null!;
        public virtual DbSet<FormasPagosUsuario> FormasPagosUsuarios { get; set; } = null!;
        public virtual DbSet<Mensaje> Mensajes { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BD7B2N4\\SQLEXPRESS01;Database=TiendaVirtual;Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.Property(e => e.ArticuloId)
                    .ValueGeneratedNever()
                    .HasColumnName("ArticuloID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("money");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articulos_Usuarios");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.Property(e => e.CuentaId)
                    .ValueGeneratedNever()
                    .HasColumnName("CuentaID");

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.NumeroTarjerta)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuentas_Usuarios");
            });

            modelBuilder.Entity<FormasPagosUsuario>(entity =>
            {
                entity.HasKey(e => e.FormaPagoId);

                entity.Property(e => e.FormaPagoId)
                    .ValueGeneratedNever()
                    .HasColumnName("FormaPagoID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            });

            modelBuilder.Entity<Mensaje>(entity =>
            {
                entity.Property(e => e.MensajeId)
                    .ValueGeneratedNever()
                    .HasColumnName("MensajeID");

                entity.Property(e => e.Mensaje1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Mensaje");

                entity.Property(e => e.PedidoId).HasColumnName("PedidoID");

                entity.Property(e => e.UsuarioIddestino).HasColumnName("UsuarioIDDestino");

                entity.Property(e => e.UsuarioIdorigen).HasColumnName("UsuarioIDOrigen");

            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.PedidoId)
                    .ValueGeneratedNever()
                    .HasColumnName("PedidoID");

                entity.Property(e => e.ArticuloId).HasColumnName("ArticuloID");

                entity.Property(e => e.FormaPagoId).HasColumnName("FormaPagoID");

                entity.Property(e => e.PaisDestino)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinciaDestino)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SectorDestino)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.Property(e => e.RolId)
                    .ValueGeneratedNever()
                    .HasColumnName("RolID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("UsuarioID");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RolId).HasColumnName("RolID");

               
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
