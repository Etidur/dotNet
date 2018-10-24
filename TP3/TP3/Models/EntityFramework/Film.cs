using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models.EntityFramework
{

    [Table("T_E_FILM_FLM")]
    public class Film
    {
        public Film()
        {
            AvisFilm = new HashSet<Avis>();
            FavorisFilm = new HashSet<Favori>();
        }

        //On ne met pas [Key] et on la créé dans l'API fluent afin de pouvoir définir son nom
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] pas utile car Identity par défaut dans SQL Server
        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [Required]
        [Column("FLM_TITRE")]
        [StringLength(100)]
        public string Titre { get; set; }

        [Column("FLM_SYNOPSIS")]
        [StringLength(500)]
        public string Synopsis { get; set; }

        [Column("FLM_DATEPARUTION", TypeName = "datetime")]
        public DateTime DateParution { get; set; }

        [Column("FLM_DUREE", TypeName = "numeric(3, 0)")]
        public decimal Duree { get; set; }

        [Required]
        [Column("FLM_GENRE")]
        [StringLength(30)]
        public string Genre { get; set; }

        [Column("FLM_URLPHOTO")]
        [StringLength(200)]
        public string UrlPhoto { get; set; }

        [InverseProperty("FilmAvis")]
        public ICollection<Avis> AvisFilm { get; set; }

        [InverseProperty("FilmFavori")]
        public ICollection<Favori> FavorisFilm { get; set; }
    }
}
