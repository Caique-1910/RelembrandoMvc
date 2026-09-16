using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Projeto1.Models;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<livro> livro { get; set; }

    public virtual DbSet<usuario> usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=biblioteca;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<livro>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__livro__3213E83FCD5E5F89");

            entity.Property(e => e.id).ValueGeneratedNever();
        });

        modelBuilder.Entity<usuario>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__usuario__3213E83F9DF7E042");

            entity.Property(e => e.id).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
