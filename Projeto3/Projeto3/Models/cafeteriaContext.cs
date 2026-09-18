using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Projeto3.Models;

public partial class cafeteriaContext : DbContext
{
    public cafeteriaContext()
    {
    }

    public cafeteriaContext(DbContextOptions<cafeteriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<item> item { get; set; }

    public virtual DbSet<usuario> usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=cafeteria;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<item>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__item__3213E83F94F98DAF");

            entity.Property(e => e.descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.nomeItem)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.preco).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<usuario>(entity =>
        {
            entity.HasKey(e => e.usuarioid).HasName("PK__usuario__A5B49E467B232608");

            entity.HasIndex(e => e.email, "UQ__usuario__AB6E61642014CC35").IsUnique();

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
