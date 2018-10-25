using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinal.Model
{
    public class Film
    {
        public Film()
        {
            AvisFilm = new HashSet<Avis>();
            FavorisFilm = new HashSet<Favori>();
        }

        //On ne met pas [Key] et on la créé dans l'API fluent afin de pouvoir définir son nom
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] pas utile car Identity par défaut dans SQL Server
        public int FilmId { get; set; }

        [Required]
        public string Titre { get; set; }

        public string Synopsis { get; set; }

        public DateTime DateParution { get; set; }

        public decimal Duree { get; set; }

        [Required]
        public string Genre { get; set; }

        public string UrlPhoto { get; set; }

        public ICollection<Avis> AvisFilm { get; set; }

        public ICollection<Favori> FavorisFilm { get; set; }
    }
}
