using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Projeto2.Models;

public partial class mercadoContext : DbContext
{
    public mercadoContext()
    {
    }

    public mercadoContext(DbContextOptions<mercadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<item> item { get; set; }

    public virtual DbSet<usuario> usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=mercado;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<item>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__item__3213E83FAA0EF48C");

            entity.Property(e => e.nomeitem)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<usuario>(entity =>
        {
            entity.HasKey(e => e.usuarioid).HasName("PK__usuario__A5B49E46442BB1F1");

            entity.HasIndex(e => e.email, "UQ__usuario__AB6E6164FF57C552").IsUnique();

            entity.Property(e => e.usuarioid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.senha)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
