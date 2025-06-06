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
            entity.Property(e => e.UserPassword)
                .HasColumnType("character varying")
                .HasColumnName("user_password");
            entity.Property(e => e.UserRegistrationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("user_registration_time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
