using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webBuildings;

public partial class SystemBuildingContext : DbContext
{
    public SystemBuildingContext()
    {
    }

    public SystemBuildingContext(DbContextOptions<SystemBuildingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=systemBuilding;user=app_user1;password=pass123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("building");

            entity.HasIndex(e => e.Jobid, "FKbuilding824554");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Progress).HasColumnName("progress");

            entity.HasOne(d => d.Job).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.Jobid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKbuilding824554");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contract");

            entity.HasIndex(e => e.Personaid, "FKcontract196584");

            entity.HasIndex(e => e.Buildingid, "FKcontract22492");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Available)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("available");
            entity.Property(e => e.Buildingid).HasColumnName("buildingid");
            entity.Property(e => e.FinishDate)
                .HasColumnType("date")
                .HasColumnName("finish_date");
            entity.Property(e => e.Personaid).HasColumnName("personaid");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Building).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Buildingid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKcontract22492");

            entity.HasOne(d => d.Persona).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Personaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKcontract196584");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("job");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Progress).HasColumnName("progress");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("persona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Rut)
                .HasMaxLength(255)
                .HasColumnName("rut");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
