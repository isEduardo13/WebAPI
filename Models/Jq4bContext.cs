using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

public partial class Jq4bContext : DbContext
{
    public Jq4bContext()
    {
    }

    public Jq4bContext(DbContextOptions<Jq4bContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Detalleventas> Detalleventas { get; set; }

    public virtual DbSet<Encargadotienda> Encargadotienda { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Productostienda> Productostienda { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Tiendas> Tiendas { get; set; }

    public virtual DbSet<Ventas> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost; user=frontend; password=T5z21te0273; database=jq4b; port=3306");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categorias");

            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Categoria");
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Usuario, "Usuario").IsUnique();

            entity.Property(e => e.Apemat).HasMaxLength(100);
            entity.Property(e => e.Apepat).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(15);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Pwd).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.Usuario).HasMaxLength(50);
        });

        modelBuilder.Entity<Detalleventas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detalleventas");

            entity.HasIndex(e => e.IdProducto, "fk_dv_p");

            entity.HasIndex(e => e.IdVenta, "fk_dv_v");

            entity.Property(e => e.Cantidad).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Detalleventas)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dv_p");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.Detalleventas)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dv_v");
        });

        modelBuilder.Entity<Encargadotienda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("encargadotienda");

            entity.HasIndex(e => e.Usuario, "Usuario").IsUnique();

            entity.HasIndex(e => e.IdRol, "fk_encargado_rol");

            entity.Property(e => e.Apemat).HasMaxLength(100);
            entity.Property(e => e.Apepat).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(15);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Pwd).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
            entity.Property(e => e.Usuario).HasMaxLength(50);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Encargadotienda)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_encargado_rol");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.HasIndex(e => e.IdCategoria, "fk_productos_categorias");

            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Producto");
            entity.Property(e => e.Precio).HasPrecision(10);
            entity.Property(e => e.Stock).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_productos_categorias");
        });

        modelBuilder.Entity<Productostienda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productostienda");

            entity.HasIndex(e => e.IdProducto, "fk_pt_prod");

            entity.HasIndex(e => e.IdTienda, "fk_pt_tienda");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Productostienda)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pt_prod");

            entity.HasOne(d => d.IdTiendaNavigation).WithMany(p => p.Productostienda)
                .HasForeignKey(d => d.IdTienda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pt_tienda");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Rol, "Rol").IsUnique();

            entity.Property(e => e.Rol).HasMaxLength(100);
        });

        modelBuilder.Entity<Tiendas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tiendas");

            entity.HasIndex(e => e.IdEncargado, "fk_tiendas_encargados");

            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.NombreTienda)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Tienda");
            entity.Property(e => e.Telefono).HasMaxLength(15);

            entity.HasOne(d => d.IdEncargadoNavigation).WithMany(p => p.Tiendas)
                .HasForeignKey(d => d.IdEncargado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tiendas_encargados");
        });

        modelBuilder.Entity<Ventas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ventas");

            entity.HasIndex(e => e.IdCliente, "fk_ventas_cliente");

            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Hora).HasColumnType("time");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Ventas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ventas_cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
