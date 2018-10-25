using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinal.Model
{
    public class Favori
    {
        public int CompteId { get; set; }
        public int FilmId { get; set; }

        public Compte CompteFavori { get; set; }
        public Film FilmFavori { get; set; }
    }
}
