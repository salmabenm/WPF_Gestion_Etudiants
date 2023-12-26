using System;
using System.Collections.Generic;
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
using Telerik.Windows.Controls;
using WPF_Gestion_Etudiants.Data;
using WPF_Gestion_Etudiants.View.Registre;

namespace WPF_Gestion_Etudiants.View.Gestion.Etudiant
{
    /// <summary>
    /// Logique d'interaction pour UserControlEtudiant.xaml
    /// </summary>
    public partial class UserControlEtudiant : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public UserControlEtudiant()
        {
            InitializeComponent();
            radDataForm.EditEnded += RadDataForm_EditEnded;
            LoadData();


        }

        private void LoadData()
        {
            var etudiantData = from etudiant in db.etudiants
                               select etudiant;

            myDataGridEtudiant.ItemsSource = etudiantData;
        }

        private void RadGridView_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            var selectedEtudiant = myDataGridEtudiant.SelectedItem as etudiant;

            if (selectedEtudiant != null)
            {
                radDataForm.CurrentItem = selectedEtudiant;
            }
        }


        private void RadDataForm_UpdateCommand(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SubmitChanges();
                MessageBox.Show("Update successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}");
            }
        }

        private void RadDataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
        {
            myDataGridEtudiant.Items.Refresh();
        }



        private void Button_ClickModifier(object sender, RoutedEventArgs e)
        {

            var selectedEtudiant = myDataGridEtudiant.SelectedItem as etudiant;

            if (selectedEtudiant != null)
            {

                ValiderMod.Visibility = Visibility.Visible;
                myDataGridEtudiant.Visibility = myDataGridEtudiant.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                radDataForm.Visibility = radDataForm.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                radDataForm.CurrentItem = selectedEtudiant;
            }
            else
            {
                MessageBox.Show("Please select an item to modify.");
            }



        }

        private void Button_ClickValider(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SubmitChanges();
                MessageBox.Show("Update successful!");
                radDataForm.Visibility = Visibility.Collapsed;
                myDataGridEtudiant.Visibility = Visibility.Visible;
                ValiderMod.Visibility = Visibility.Collapsed;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}");
            }
        }

        private void FiliereComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filiereComboBox.SelectedItem != null)
            {
                string selectedFiliere = ((ComboBoxItem)filiereComboBox.SelectedItem).Content.ToString();
                typeFiliereLabel.Content = selectedFiliere;



                var filteredEtudiants = from etudiant in db.etudiants
                                        where etudiant.FiliereId == GetFiliereId(selectedFiliere)
                                        select etudiant;


                var filiereData = (from filiere in db.filieres
                                   where filiere.Nom == selectedFiliere
                                   select filiere).FirstOrDefault();


                if (filiereData != null)
                {

                    id.Content = filiereData.filiereId.ToString();
                    responsable.Content = filiereData.responsable;
                }



                myDataGridEtudiant.ItemsSource = filteredEtudiants.ToList();
            }
        }


        private int GetFiliereId(string filiere)
        {


            switch (filiere)
            {
                case "CP1":
                    return 1;
                case "CP2":
                    return 2;
                case "GIIA":
                    return 3;
                case "GTR":
                    return 4;
                case "GATE":
                    return 5;
                case "GPMA":
                    return 6;
                case "GINDUS":
                    return 7;

                default:
                    return 0;
            }
        }


    }
}
