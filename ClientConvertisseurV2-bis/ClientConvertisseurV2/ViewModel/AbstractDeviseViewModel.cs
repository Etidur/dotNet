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
    public abstract class AbstractDeviseViewModel : ViewModelBase
    {
        protected ObservableCollection<Devise> _comboBoxDevises;
        public ICommand BtnSetConversion { get; private set; }
        protected string _montantEuro;
        protected string _montantDevise;
        protected Devise _devise;

        public ObservableCollection<Devise> ComboBoxDevises
        {
            get { return _comboBoxDevises; }
            set
            {
                _comboBoxDevises = value;
                RaisePropertyChanged();// Pour notifier de la modification de ses donnée
            }
        }
        public string MontantEuro {
            get { return _montantEuro; }
            set { _montantEuro = value; RaisePropertyChanged(); }
        }
        public Devise ComboBoxDeviseItem
        {
            get { return _devise; }
            set { _devise = value; RaisePropertyChanged(); }
        }
        public string MontantDevise
        {
            get { return _montantDevise; }
            set { _montantDevise = value; RaisePropertyChanged("MontantDevise"); }
        }

        /// <summary>
        /// Complète l'interface avec des valeurs dynamiques et initialise l'action du bouton
        /// </summary>
        public AbstractDeviseViewModel()
        {
            ActionGetData();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        /// <summary>
        /// Calcule la conversion et affiche le résultat dans l'interface
        /// </summary>
        protected abstract void ActionSetConversion();

        /// <summary>
        /// Récupère la liste des devises via le service connecté à l'API
        /// </summary>
        protected async void ActionGetData()
        {
            WSService connection = WSService.GetInstance();
            var result = await connection.GetAllDevisesAsync("Devise");
            this.ComboBoxDevises = new ObservableCollection<Devise>(result);
        }

        /// <summary>
        /// Afficher un message dans une boîte de dialogue
        /// </summary>
        /// <param name="message">Message (String) à afficher</param>
        protected async void MessageBox(string message)
        {
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }
    }
}
