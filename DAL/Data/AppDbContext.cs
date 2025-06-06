using System;
using System.Collections.Generic;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Project;Username=roman;Password=fleshka5418");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pk");

            entity.ToTable("User");

            entity.HasIndex(e => e.UserEmail, "user_useremail_uindex").IsUnique();

            entity.Property(e => e.UserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("user_id");
            entity.Property(e => e.RefreshToken)
                .HasColumnType("character varying")
                .HasColumnName("refresh_token");
            entity.Property(e => e.UserEmail)
                .HasColumnType("character varying")
                .HasColumnName("user_email");
            entity.Property(e => e.UserIsBlocked)
                .HasDefaultValue(false)
                .HasColumnName("user_is_blocked");
            entity.Property(e => e.UserLastLoginTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("user_last_login_time");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
            entity.Property(e => e.UserPasswordHash)
                .HasColumnType("character varying")
                .HasColumnName("user_password_hash");
            entity.Property(e => e.UserRegistrationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("user_registration_time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
