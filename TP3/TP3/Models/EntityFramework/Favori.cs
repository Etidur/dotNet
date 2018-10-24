using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models.EntityFramework
{
    [Table("T_E_FAVORI_FAV")]
    public class Favori
    {
        [Column("CPT_ID")]
        public int CompteId { get; set; }
        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [ForeignKey("CompteId")]
        [InverseProperty("FavorisCompte")]
        public Compte CompteFavori { get; set; }
        [ForeignKey("FilmId")]
        [InverseProperty("FavorisFilm")]
        public Film FilmFavori { get; set; }
    }
}
