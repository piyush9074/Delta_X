using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Delta_XServices.Models
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
        public virtual DbSet<MovieActorDetails> MovieActorDetails { get; set; }
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
                entity.Property(e => e.Id).HasColumnName("id");

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
                entity.Property(e => e.DateOfRelease)
                    .HasColumnName("Date_of_Release")
                    .HasColumnType("date");

                entity.Property(e => e.FkProducer).HasColumnName("fk_producer");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkProducerNavigation)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.FkProducer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Producer");
            });

            modelBuilder.Entity<MovieActorDetails>(entity =>
            {
                entity.ToTable("Movie_Actor_Details");

                entity.Property(e => e.FkActorId).HasColumnName("fk_actor_id");

                entity.Property(e => e.FkMovieId).HasColumnName("fk_movie_id");

                entity.HasOne(d => d.FkActor)
                    .WithMany(p => p.MovieActorDetails)
                    .HasForeignKey(d => d.FkActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Actor_Details_Actor");

                entity.HasOne(d => d.FkMovie)
                    .WithMany(p => p.MovieActorDetails)
                    .HasForeignKey(d => d.FkMovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Actor_Details_Movie");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

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
