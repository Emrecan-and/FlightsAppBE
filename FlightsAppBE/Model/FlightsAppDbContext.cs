using System;
using System.Collections.Generic;
using FlightsAppBE.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightsAppBE.Repository;

public partial class FlightsAppDbContext : DbContext
{
    public FlightsAppDbContext()
    {
    }

    public FlightsAppDbContext(DbContextOptions<FlightsAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Airr> Airrs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-JEUIHMH\\SQLEXPRESS;Initial Catalog=FlightsApp;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Airports__A25C5AA68D82E037");
        });

        modelBuilder.Entity<Airr>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Airr$__A25C5AA657B9146C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
