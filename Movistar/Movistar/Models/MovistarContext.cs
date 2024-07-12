using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Movistar.Models;

public partial class MovistarContext : DbContext
{
    public MovistarContext()
    {
    }

    public MovistarContext(DbContextOptions<MovistarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Planzona> Planzonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-NP5N56G\\SQLEXPRESS;database=Movistar;integrated security=true; Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__CLIENTE__71ABD08708BF99AD");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreEs)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Estado)
                .HasConstraintName("FK__CLIENTE__Estado__5AB9788F");

            entity.HasOne(d => d.NombreEsNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.NombreEs)
                .HasConstraintName("FK__CLIENTE__NombreE__5BAD9CC8");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity.HasKey(e => e.NombreEs).HasName("PK__DISTRITO__E692121EEA72194B");

            entity.ToTable("DISTRITO");

            entity.Property(e => e.NombreEs)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodDis).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Planzona>(entity =>
        {
            entity.HasKey(e => e.NombrePlan).HasName("PK__PLANZONA__B42E20D1FCE23F4B");

            entity.ToTable("PLANZONA");

            entity.Property(e => e.NombrePlan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Duracion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
