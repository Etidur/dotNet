using ClientConvertisseurV2.Model;
using ClientConvertisseurV2.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace ClientConvertisseurV2.ViewModel
{
    /// <summary>
    /// Classe faisant le lien entre le modèle et la vue
    /// </summary>
    public class EuroToDevViewModel : AbstractDeviseViewModel
    {
        /// <summary>
        /// Complète l'interface avec des valeurs dynamiques et initialise l'action du bouton
        /// </summary>
        public EuroToDevViewModel() : base()
        {
        }

        /// <summary>
        /// Calcule la conversion et affiche le résultat dans l'interface
        /// </summary>
        protected override void ActionSetConversion()
        {
            double montant = 0, taux = 1;

            try
            {
                montant = Convert.ToDouble(_montantEuro);
                taux = ComboBoxDeviseItem.Taux;
            }
            catch (FormatException)
            {
                this.MessageBox("Le montant n'est pas correct");
            }
            catch (NullReferenceException)
            {
                this.MessageBox("Aucune devise n'a été séléctionnée");
            }

            MontantDevise= Convert.ToString(montant * taux);
         }
    }
}
