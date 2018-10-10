using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSConvertisseur.Models
{
    /// <summary>
    /// Devise
    /// </summary>
    public class Devise
    {
        /// <summary>
        /// Id de la devise
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome de la devise
        /// </summary>
        [Required]
        public string NomDevise { get; set; }

        /// <summary>
        /// Taux de conversion de la devise
        /// </summary>
        public double Taux { get; set; }

        public Devise()
        {

        }
        public Devise(int id, string nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }
    }
}
