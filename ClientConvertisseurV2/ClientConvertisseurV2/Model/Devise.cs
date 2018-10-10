using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Model
{
    /// <summary>
    /// Classe décrivant une devise
    /// </summary>
    public class Devise
    {
        public int Id { get; set; }

        [Required]
        public string NomDevise { get; set; }

        public double Taux { get; set; }
    }
}
