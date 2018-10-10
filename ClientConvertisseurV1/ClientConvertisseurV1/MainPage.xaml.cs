using ClientConvertisseurV1.Model;
using ClientConvertisseurV1.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientConvertisseurV1
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static List<Devise> devises;

        public MainPage()
        {
            this.InitializeComponent();
            ActionGetData();
        }

        /// <summary>
        /// Récupère la liste des devises via l'API
        /// </summary>
        private async void ActionGetData()
        {
            WSService wSService = WSService.GetInstance();
            List<Devise> devises = await wSService.GetAllDevisesAsync("Devise");

            this.comboBox.DataContext = devises;
        }

        /// <summary>
        /// Calcule et affiche la conversion du montant lors du clic sur le boutton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            double montant = 0, taux = 1;

            try
            {
                montant = Convert.ToDouble(textBoxMontant.Text);
                Devise nouvelleDevise = (Devise)comboBox.SelectedItem;
                taux = nouvelleDevise.Taux;
            } catch(FormatException)
            {
                this.MessageBox("Le montant n'est pas correct");
            } catch (NullReferenceException)
            {
                this.MessageBox("Aucune devise n'a été séléctionnée");
            }

            textBoxResultat.Text = Convert.ToString(montant * taux);
        }

        /// <summary>
        /// Afficher un message dans une boîte de dialogue
        /// </summary>
        /// <param name="message">Message (String) à afficher</param>
        private async void MessageBox(string message)
        {
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }
    }
}
