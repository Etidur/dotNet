using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3.Models.EntityFramework
{
    [Table("T_E_COMPTE_CPT")]
    public class Compte
    {
        public Compte()
        {
            AvisCompte = new HashSet<Avis>();
            FavorisCompte = new HashSet<Favori>();
        }

        [Column("CPT_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompteId { get; set; }

        [Required]
        [Column("CPT_NOM")]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        [Column("CPT_PRENOM")]
        [StringLength(50)]
        public string Prenom { get; set; }

        [Column("CPT_TELPORTABLE", TypeName = "char(10)")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Le téléphone portable doit contenir 10 chiffres")]
        [StringLength(10)]
        public string TelPortable { get; set; }

        [Required]
        [Column("CPT_MEL")]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
        public string Mel{ get; set; }

        [Column("CPT_PWD")]
        [MaxLength(64)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[-+!*$@%_])([-+!*$@%_\w]{6,10})$", ErrorMessage = "Le mot de passe doit contenir entre 6 et 10 caractères avec au moins 1 lettre majuscule, 1 chiffre et 1 caractère spécial")]
        public string Pwd{ get; set; }

        [Required]
        [Column("CPT_RUE")]
        [MaxLength(200)]
        public string Rue{ get; set; }

        [Required]
        [Column("CPT_CP", TypeName = "char(5)")] // Impossible de mettre char tout court => char(5)
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Le code postal doit contenir 5 chiffres")]
        [StringLength(5)]
        public string CodePostal{ get; set; }

        [Required]
        [Column("CPT_VILLE")]
        [MaxLength(50)]
        public string Ville{ get; set; }

        [Required]
        [Column("CPT_PAYS")]
        [MaxLength(50)]
        public string Pays{ get; set; }

        [Column("CPT_LATITUDE")]
        public float? Latitude { get; set; }

        [Column("CPT_LONGITUDE")]
        public float? Longitude { get; set; }

        [InverseProperty("CompteAvis")]
        public ICollection<Avis> AvisCompte { get; set; }

        [InverseProperty("CompteFavori")]
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
