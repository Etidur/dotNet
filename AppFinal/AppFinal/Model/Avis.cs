using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinal.Model
{
    public class Avis
    {
        public int CompteId { get; set; }

        public int FilmId { get; set; }

        public DateTime DateAvis { get; set; }

        [Required]
        public string Titre { get; set; }

        [Required]
        public string Detail { get; set; }

        public decimal Note { get; set; }

        public Compte CompteAvis { get; set; }

        public Film FilmAvis { get; set; }
    }
}
