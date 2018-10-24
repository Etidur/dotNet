using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models.EntityFramework
{
    [Table("T_E_FILM_FLM")]
    public class Film
    {
    
        [Key]
        [Column("FLM_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmId { get; set; }

        [Required]
        [Column("FLM_TITRE")]
        [StringLength(100)]
        public string Titre { get; set; }

        [Column("FLM_SYNOPSIS")]
        [StringLength(500)]
        public string Synopsis { get; set; }



        [Column("FLM_DATEPARUTION")]
        public string DateParution { get; set; }
        
        

        [Required]
        [Column("FLM_DUREE")]
        [DataType("decimal(3,0")]
        public Decimal Duree { get; set; }

        [Required]
        [Column("FLM_GENRE")]
        [StringLength(30)]
        public String Genre { get; set; }
        
        [Required]
        [Column("FLM_URLPHOTO")]
        [StringLength(200)]
        public String UrlPhoto { get; set; }







        [ForeignKey("AvisFilm")]
        [InverseProperty("Film")]
        public Avis AvisFilm { get; set; }
        [InverseProperty("FilmAvis")]
        public ICollection<Avis> Avis { get; set; }

    }
}
