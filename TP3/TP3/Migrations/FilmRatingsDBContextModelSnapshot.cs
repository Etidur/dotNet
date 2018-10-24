﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP3.Models.EntityFramework;

namespace TP3.Migrations
{
    [DbContext(typeof(FilmRatingsDBContext))]
    partial class FilmRatingsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TP3.Models.EntityFramework.Avis", b =>
                {
                    b.Property<int>("CompteId")
                        .HasColumnName("CPT_ID");

                    b.Property<int>("FilmId")
                        .HasColumnName("FLM_ID");

                    b.Property<DateTime>("DateAvis")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AVI_DATE")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnName("AVI_DETAIL")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<decimal>("Note")
                        .HasColumnName("AVI_NOTE")
                        .HasColumnType("numeric(1, 0)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnName("AVI_TITRE")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("CompteId", "FilmId")
                        .HasName("PK_AVI");

                    b.HasIndex("FilmId");

                    b.ToTable("T_E_AVIS_AVI");
                });

            modelBuilder.Entity("TP3.Models.EntityFramework.Compte", b =>
                {
                    b.Property<int>("CompteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CPT_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasColumnName("CPT_CP")
                        .HasColumnType("char(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<float?>("Latitude")
                        .HasColumnName("CPT_LATITUDE");

                    b.Property<float?>("Longitude")
                        .HasColumnName("CPT_LONGITUDE");

                    b.Property<string>("Mel")
                        .IsRequired()
                        .HasColumnName("CPT_MEL")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("CPT_NOM")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Pays")
                        .IsRequired()
                        .HasColumnName("CPT_PAYS")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnName("CPT_PRENOM")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Pwd")
                        .HasColumnName("CPT_PWD")
                        .HasMaxLength(64)
                        .IsUnicode(false);

                    b.Property<string>("Rue")
                        .IsRequired()
                        .HasColumnName("CPT_RUE")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("TelPortable")
                        .HasColumnName("CPT_TELPORTABLE")
                        .HasColumnType("char(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnName("CPT_VILLE")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("CompteId")
                        .HasName("PK_CPT");

                    b.HasIndex("Mel")
                        .IsUnique()
                        .HasName("UQ_CPT_MEL");

                    b.ToTable("T_E_COMPTE_CPT");
                });

            modelBuilder.Entity("TP3.Models.EntityFramework.Favori", b =>
                {
                    b.Property<int>("CompteId")
                        .HasColumnName("CPT_ID");

                    b.Property<int>("FilmId")
                        .HasColumnName("FLM_ID");

                    b.HasKey("CompteId", "FilmId")
                        .HasName("PK_FAV");

                    b.HasIndex("FilmId");

                    b.ToTable("T_E_FAVORI_FAV");
                });

            modelBuilder.Entity("TP3.Models.EntityFramework.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FLM_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateParution")
                        .HasColumnName("FLM_DATEPARUTION")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Duree")
                        .HasColumnName("FLM_DUREE")
                        .HasColumnType("numeric(3, 0)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnName("FLM_GENRE")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Synopsis")
                        .HasColumnName("FLM_SYNOPSIS")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnName("FLM_TITRE")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("UrlPhoto")
                        .HasColumnName("FLM_URLPHOTO")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("FilmId")
                        .HasName("PK_FLM");

                    b.ToTable("T_E_FILM_FLM");
                });

            modelBuilder.Entity("TP3.Models.EntityFramework.Avis", b =>
                {
                    b.HasOne("TP3.Models.EntityFramework.Compte", "CompteAvis")
                        .WithMany("AvisCompte")
                        .HasForeignKey("CompteId")
                        .HasConstraintName("FK_AVI_CPT");

                    b.HasOne("TP3.Models.EntityFramework.Film", "FilmAvis")
                        .WithMany("AvisFilm")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("FK_AVI_FLM");
                });

            modelBuilder.Entity("TP3.Models.EntityFramework.Favori", b =>
                {
                    b.HasOne("TP3.Models.EntityFramework.Compte", "CompteFavori")
                        .WithMany("FavorisCompte")
                        .HasForeignKey("CompteId")
                        .HasConstraintName("FK_FAV_CPT");

                    b.HasOne("TP3.Models.EntityFramework.Film", "FilmFavori")
                        .WithMany("FavorisFilm")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("FK_FAV_FLM");
                });
#pragma warning restore 612, 618
        }
    }
}
