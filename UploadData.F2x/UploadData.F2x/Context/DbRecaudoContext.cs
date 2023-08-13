using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UploadData.F2x.Context;

public partial class DbRecaudoContext : DbContext
{
    public DbRecaudoContext()
    {
    }

    public DbRecaudoContext(DbContextOptions<DbRecaudoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Recaudo> Recaudos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=54.209.174.241;Database=JhoinnelLiscano;Integrated Security=False;Trusted_Connection=False;TrustServerCertificate=True; User id=pruebas22; password=pruebas22");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recaudo>(entity =>
        {
            entity.HasKey(e => new { e.Fecha, e.Estacion, e.Sentido, e.Hora, e.Categoria }).HasName("PK__Recaudo__C6CB58B0753DC1E4");

            entity.ToTable("Recaudo");

            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Estacion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sentido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ValorTabulado).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
