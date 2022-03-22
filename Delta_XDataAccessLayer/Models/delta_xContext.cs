using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Delta_XDataAccessLayer.Models
{
    public partial class delta_xContext : DbContext
    {
        public delta_xContext()
        {
        }

        public delta_xContext(DbContextOptions<delta_xContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieActor> MovieActor { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source =PITSU\\MSSQLSERVER01;Initial Catalog=delta_x;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_Actor_1");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Actor")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("Date_of_Birth")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("AK_Name")
                    .IsUnique();

                entity.Property(e => e.DateOfRelease)
                    .HasColumnName("Date_of_Release")
                    .HasColumnType("date");

                entity.Property(e => e.FkProducer)
                    .IsRequired()
                    .HasColumnName("fk_producer")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Plot)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkProducerNavigation)
                    .WithMany(p => p.Movie)
                    .HasPrincipalKey(p => p.Name)
                    .HasForeignKey(d => d.FkProducer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movie__fk_produc__6E01572D");
            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.ToTable("Movie_Actor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActorNameNavigation)
                    .WithMany(p => p.MovieActor)
                    .HasPrincipalKey(p => p.Name)
                    .HasForeignKey(d => d.ActorName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Actor_Actor");

                entity.HasOne(d => d.MovieNameNavigation)
                    .WithMany(p => p.MovieActor)
                    .HasPrincipalKey(p => p.Name)
                    .HasForeignKey(d => d.MovieName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Actor_Movie");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Producer")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bio)
                    .HasColumnName("bio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("Date_of_Birth")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
