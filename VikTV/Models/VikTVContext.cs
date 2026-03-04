using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VikTV.Models;

public partial class VikTVContext : DbContext
{
    public VikTVContext()
    {
    }

    public VikTVContext(DbContextOptions<VikTVContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<TitleCredit> TitleCredits { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSubscribtion> UserSubscribtions { get; set; }

    public virtual DbSet<WatchHistory> WatchHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=VikTV;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__genres__18428D429BEBCE7D");

            entity.ToTable("genres");

            entity.HasIndex(e => e.GenreName, "UQ__genres__1E98D1511730BFBB").IsUnique();

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(50)
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__movies__83CDF749880ECD0A");

            entity.ToTable("movies");

            entity.Property(e => e.MovieId)
                .ValueGeneratedNever()
                .HasColumnName("movie_id");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.VideoUrl)
                .HasMaxLength(255)
                .HasColumnName("video_url");

            entity.HasOne(d => d.MovieNavigation).WithOne(p => p.Movie)
                .HasForeignKey<Movie>(d => d.MovieId)
                .HasConstraintName("FK_Movies_Titles");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__people__543848DF9D0D8C74");

            entity.ToTable("people");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__profiles__AEBB701F91B0E6A3");

            entity.ToTable("profiles");

            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.IsKids)
                .HasDefaultValue(false)
                .HasColumnName("is_kids");
            entity.Property(e => e.ProfileName)
                .HasMaxLength(50)
                .HasColumnName("profile_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Profiles_User");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.ShowId).HasName("PK__shows__2B97D71CAA76A135");

            entity.ToTable("shows");

            entity.Property(e => e.ShowId)
                .ValueGeneratedNever()
                .HasColumnName("show_id");
            entity.Property(e => e.NumberOfSeasons)
                .HasDefaultValue(1)
                .HasColumnName("number_of_seasons");

            entity.HasOne(d => d.ShowNavigation).WithOne(p => p.Show)
                .HasForeignKey<Show>(d => d.ShowId)
                .HasConstraintName("FK_Shows_Titles");
        });

        modelBuilder.Entity<SubscriptionPlan>(entity =>
        {
            entity.HasKey(e => e.PlanId).HasName("PK__subscrip__BE9F8F1D4EF57340");

            entity.ToTable("subscription_plans");

            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.MaxResolution)
                .HasMaxLength(50)
                .HasColumnName("max_resolution");
            entity.Property(e => e.MaxScreens).HasColumnName("max_screens");
            entity.Property(e => e.PlanName)
                .HasMaxLength(50)
                .HasColumnName("plan_name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.TitleId).HasName("PK__titles__1062D977BFF2AF84");

            entity.ToTable("titles");

            entity.Property(e => e.TitleId).HasColumnName("title_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.MaturityRating)
                .HasMaxLength(30)
                .HasColumnName("maturity_rating");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ReleaseYear).HasColumnName("release_year");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasColumnName("type");

            entity.HasMany(d => d.Genres).WithMany(p => p.Titles)
                .UsingEntity<Dictionary<string, object>>(
                    "TitleGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_TG_Genre"),
                    l => l.HasOne<Title>().WithMany()
                        .HasForeignKey("TitleId")
                        .HasConstraintName("FK_TG_Title"),
                    j =>
                    {
                        j.HasKey("TitleId", "GenreId").HasName("PK__title_ge__21E6F1A3AF60C51E");
                        j.ToTable("title_genres");
                        j.IndexerProperty<int>("TitleId").HasColumnName("title_id");
                        j.IndexerProperty<int>("GenreId").HasColumnName("genre_id");
                    });
        });

        modelBuilder.Entity<TitleCredit>(entity =>
        {
            entity.HasKey(e => new { e.TitleId, e.PersonId }).HasName("PK__title_cr__F5215DFAB9E06AEC");

            entity.ToTable("title_credits");

            entity.Property(e => e.TitleId).HasColumnName("title_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");

            entity.HasOne(d => d.Person).WithMany(p => p.TitleCredits)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_TC_Person");

            entity.HasOne(d => d.Title).WithMany(p => p.TitleCredits)
                .HasForeignKey(d => d.TitleId)
                .HasConstraintName("FK_TC_Title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FC92A75BC");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164B9475F9D").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registration_date");
        });

        modelBuilder.Entity<UserSubscribtion>(entity =>
        {
            entity.HasKey(e => e.UserSubscribtionId).HasName("PK__user_sub__87272F7A33520A19");

            entity.ToTable("user_subscribtion");

            entity.Property(e => e.UserSubscribtionId).HasColumnName("user_subscribtion_id");
            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Plan).WithMany(p => p.UserSubscribtions)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSub_Plan");

            entity.HasOne(d => d.User).WithMany(p => p.UserSubscribtions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserSub_User");
        });

        modelBuilder.Entity<WatchHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__watch_hi__096AA2E9224C4D2D");

            entity.ToTable("watch_history");

            entity.Property(e => e.HistoryId).HasColumnName("history_id");
            entity.Property(e => e.LastWatchedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("last_watched_at");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.ProgressMinutes)
                .HasDefaultValue(0)
                .HasColumnName("progress_minutes");
            entity.Property(e => e.TitleId).HasColumnName("title_id");

            entity.HasOne(d => d.Profile).WithMany(p => p.WatchHistories)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("FK_WH_Profile");

            entity.HasOne(d => d.Title).WithMany(p => p.WatchHistories)
                .HasForeignKey(d => d.TitleId)
                .HasConstraintName("FK_WH_Title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
