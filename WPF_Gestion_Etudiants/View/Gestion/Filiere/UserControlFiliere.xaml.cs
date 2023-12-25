using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Gestion_Etudiants.Models;

namespace WPF_Gestion_Etudiants.View.Gestion.Filiere
{
    /// <summary>
    /// Logique d'interaction pour UserControlFiliere.xaml
    /// </summary>
    public partial class UserControlFiliere : UserControl
    {

        readonly FiliereViewModel fl = new FiliereViewModel();
        public UserControlFiliere()
        {
            InitializeComponent();
            DataContext = fl;
        }
        private void AjouterButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (int.TryParse(id_txt.Text, out id))
            {
                try
                {
                    FiliereModel filiere = new FiliereModel(id, nom_txt.Text);
                    fl.AjouterFiliere(filiere);
                    MessageBox.Show("Filiere ajoutée avec succès");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Invalid input for ID. Please enter a valid integer.");
            }
        }

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (int.TryParse(id_txt.Text, out id))
            {
                try
                {
                    FiliereModel filiere = new FiliereModel(id, nom_txt.Text);
                    fl.ModifierFiliere(filiere);
                    MessageBox.Show("Filiere modifiée avec succès");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Invalid input for ID. Please enter a valid integer.");
            }

        }

        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (int.TryParse(id_txt.Text, out id))
            {
                try
                {
                    FiliereModel filiere = new FiliereModel(id, nom_txt.Text);
                    fl.SupprimerFiliere(filiere);
                    MessageBox.Show("Filiere supprimée avec succès");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Invalid input for ID. Please enter a valid integer.");
            }
        }
    }

}
