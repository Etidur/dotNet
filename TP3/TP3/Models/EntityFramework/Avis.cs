using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models.EntityFramework
{
    [Table("T_E_AVIS_AVI")]
    public class Avis
    {
        [Column("CPT_ID")]
        public int CompteId { get; set; }

        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [Column("AVI_DATE", TypeName = "datetime")]
        public DateTime DateAvis { get; set; }

        [Required]
        [Column("AVI_TITRE")]
        [StringLength(100)]
        public string Titre { get; set; }

        [Required]
        [Column("AVI_DETAIL")]
        [StringLength(2000)]
        public string Detail { get; set; }

        [Column("AVI_NOTE", TypeName = "numeric(1, 0)")]
        public decimal Note { get; set; }

        [ForeignKey("CompteId")]
        [InverseProperty("AvisCompte")]
        public Compte CompteAvis { get; set; }

        [ForeignKey("FilmId")]
        [InverseProperty("AvisFilm")]
        public Film FilmAvis { get; set; }
    }
}
