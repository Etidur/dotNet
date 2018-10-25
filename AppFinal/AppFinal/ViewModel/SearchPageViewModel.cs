using AppFinal.Model;
using AppFinal.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace AppFinal.ViewModel
{
    public class SearchPageViewModel : ViewModelBase
    {
        protected string _valeurEmail;
        protected string _valeurCompteNom;
        protected Compte _compte;

        public string ValeurEmail
        {
            get { return _valeurEmail; }
            set { _valeurEmail = value; RaisePropertyChanged(); }
        }

        public string ValeurCompteNom
        {
            get { return _valeurCompteNom; }
            set { _valeurCompteNom = value; RaisePropertyChanged(); }
        }

        public ICommand BtnSearchExecute { get; private set; }

        public SearchPageViewModel()
        {

            BtnSearchExecute = new RelayCommand(ActionSearch);
        }

        protected async void ActionSearch()
        {
            String email = Convert.ToString(_valeurEmail);
            WSService connection = WSService.GetInstance();

            try
            {
                var result = await connection.GetCompteByEmailAsync("Comptes/GetCompteByEmail/" + email);
                
                if (result.Nom == null)
                {
                    this.MessageBox("Aucun compte correspondant n'a été trouvé");
                } else {
                    this.ValeurCompteNom = result.Nom;
                }
            }
            catch (HttpRequestException e)
            {
                this.MessageBox("La connexion à la base de donnée à échoué");
            }
        }

        protected async void MessageBox(string message)
        {
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }
    }
}