﻿using Microsoft.EntityFrameworkCore;
using Ford.Models;

namespace Ford.DataContext.Sqlite;

public partial class FordContext : DbContext
{
    public FordContext()
    {
    }

    public FordContext(DbContextOptions<FordContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bone> Bones { get; set; } = null!;
    public virtual DbSet<Horse> Horses { get; set; } = null!;
    public virtual DbSet<Save> Saves { get; set; } = null!;
    public virtual DbSet<SaveBone> SaveBones { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlite("Filename=../Ford.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Horse>(entity =>
        {
            entity.Property(e => e.HorseId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<HorseOwner>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.HorseId, });

            entity.HasOne(d => d.User)
                .WithMany(p => p.HorseOwners)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Horse)
                .WithMany(p => p.HorseOwners)
                .HasForeignKey(d => d.HorseId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Save>(entity =>
        {
            entity.Property(e => e.SaveId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SaveBone>(entity =>
        {
            entity.HasKey(e => new { e.SaveId, e.BoneId });

            entity.HasOne(d => d.Bone)
                .WithMany(p => p.SaveBones)
                .HasForeignKey(d => d.BoneId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Save)
                .WithMany(p => p.SaveBones)
                .HasForeignKey(d => d.SaveId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
