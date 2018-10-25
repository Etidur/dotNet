using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP3.Models.EntityFramework
{
    public class FilmRatingsDBContext : DbContext
    {
        public FilmRatingsDBContext()
        {
        }

        public FilmRatingsDBContext(DbContextOptions<FilmRatingsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avis> Avis { get; set; }
        public virtual DbSet<Compte> Compte { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Favori> Favori { get; set; }

        /**
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=FilmRatingsDB; Trusted_Connection=True;");
            }
        }
        **/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avis>(entity =>
            {
                entity.HasKey(e => new { e.CompteId, e.FilmId }).HasName("PK_AVI");
                entity.Property(e => e.DateAvis).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Detail).IsUnicode(false);
                entity.Property(e => e.Titre).IsUnicode(false);
                entity.HasOne(d => d.CompteAvis)
                    .WithMany(p => p.AvisCompte)
                    .HasForeignKey(d => d.CompteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AVI_CPT");
                entity.HasOne(d => d.FilmAvis)
                    .WithMany(p => p.AvisFilm)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AVI_FLM");
            });

            modelBuilder.Entity<Compte>(entity =>
            {
                entity.HasKey(e => new { e.CompteId }).HasName("PK_CPT");
                entity.HasIndex(e => e.Mel)
                    .HasName("UQ_CPT_MEL")
                    .IsUnique();
                entity.Property(e => e.CodePostal).IsUnicode(false);
                entity.Property(e => e.Mel).IsUnicode(false);
                entity.Property(e => e.Nom).IsUnicode(false);
                entity.Property(e => e.Pays).IsUnicode(false);
                entity.Property(e => e.Prenom).IsUnicode(false);
                entity.Property(e => e.Pwd).IsUnicode(false);
                entity.Property(e => e.Rue).IsUnicode(false);
                entity.Property(e => e.TelPortable).IsUnicode(false);
                entity.Property(e => e.Ville).IsUnicode(false);
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasKey(e => new { e.FilmId }).HasName("PK_FLM");
                entity.Property(e => e.Genre).IsUnicode(false);
                entity.Property(e => e.Synopsis).IsUnicode(false);
                entity.Property(e => e.Titre).IsUnicode(false);
                entity.Property(e => e.UrlPhoto).IsUnicode(false);
            });

            modelBuilder.Entity<Favori>(entity =>
            {
                entity.HasKey(e => new { e.CompteId, e.FilmId }).HasName("PK_FAV");
                entity.HasOne(d => d.CompteFavori)
                    .WithMany(p => p.FavorisCompte)
                    .HasForeignKey(d => d.CompteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAV_CPT");
                entity.HasOne(d => d.FilmFavori)
                    .WithMany(p => p.FavorisFilm)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAV_FLM");
            });
        }
    }
}
