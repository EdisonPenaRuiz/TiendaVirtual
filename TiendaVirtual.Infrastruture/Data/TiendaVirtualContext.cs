﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual DbSet<FormaPago> FormaPagos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TiposTrasaccione> TiposTrasacciones { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

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
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.Property(e => e.CuentaId)
                    .ValueGeneratedNever()
                    .HasColumnName("CuentaID");

                entity.Property(e => e.Monto).HasColumnType("money");
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.ToTable("FormaPago");

                entity.Property(e => e.FormaPagoId)
                    .ValueGeneratedNever()
                    .HasColumnName("FormaPagoID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoTransaccionId).HasColumnName("TipoTransaccionID");

                entity.HasOne(d => d.TipoTransaccion)
                    .WithMany(p => p.FormaPagos)
                    .HasForeignKey(d => d.TipoTransaccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormaPago_TiposTrasacciones");
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

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedidos_Articulos");

                entity.HasOne(d => d.FormaPago)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.FormaPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedidos_FormaPago");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedidos_Usuarios");
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

            modelBuilder.Entity<TiposTrasaccione>(entity =>
            {
                entity.HasKey(e => e.TipoTransaccionId);

                entity.Property(e => e.TipoTransaccionId)
                    .ValueGeneratedNever()
                    .HasColumnName("TipoTransaccionID");

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

                entity.Property(e => e.CuentaId).HasColumnName("CuentaID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RolId).HasColumnName("RolID");

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CuentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Cuentas");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
