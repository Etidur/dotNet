using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFinal.Model
{
    public class Compte
    {
        public Compte()
        {
            AvisCompte = new HashSet<Avis>();
            FavorisCompte = new HashSet<Favori>();
        }

        public int CompteId { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        public string TelPortable { get; set; }

        [Required]
        public string Mel { get; set; }

        public string Pwd { get; set; }

        [Required]
        public string Rue { get; set; }

        [Required]
        public string CodePostal { get; set; }

        [Required]
        public string Ville { get; set; }

        [Required]
        public string Pays { get; set; }

        public float? Latitude { get; set; }

        public float? Longitude { get; set; }

        public ICollection<Avis> AvisCompte { get; set; }

        public ICollection<Favori> FavorisCompte { get; set; }

        public override bool Equals(object obj)
        {
            var compte = obj as Compte;
            return compte != null &&
                   CompteId == compte.CompteId &&
                   Nom == compte.Nom &&
                   Prenom == compte.Prenom &&
                   TelPortable == compte.TelPortable &&
                   Mel == compte.Mel &&
                   Pwd == compte.Pwd &&
                   Rue == compte.Rue &&
                   CodePostal == compte.CodePostal &&
                   Ville == compte.Ville &&
                   Pays == compte.Pays &&
                   EqualityComparer<float?>.Default.Equals(Latitude, compte.Latitude) &&
                   EqualityComparer<float?>.Default.Equals(Longitude, compte.Longitude) &&
                   EqualityComparer<ICollection<Avis>>.Default.Equals(AvisCompte, compte.AvisCompte) &&
                   EqualityComparer<ICollection<Favori>>.Default.Equals(FavorisCompte, compte.FavorisCompte);
        }

        public override int GetHashCode()
        {
            var hashCode = 1080450202;
            hashCode = hashCode * -1521134295 + CompteId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Prenom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TelPortable);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Mel);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Pwd);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Rue);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CodePostal);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Ville);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Pays);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(Latitude);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(Longitude);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Avis>>.Default.GetHashCode(AvisCompte);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Favori>>.Default.GetHashCode(FavorisCompte);
            return hashCode;
        }
    }
}
