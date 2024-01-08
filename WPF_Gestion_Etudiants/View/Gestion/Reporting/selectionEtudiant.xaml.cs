using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Gestion_Etudiants.View.Gestion.Reporting
{
   
    public partial class selectionEtudiant : Window
    {
        public selectionEtudiant()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(cne.Text))
                {
                    string cneValue = cne.Text.Trim();

                    if (DoesCNEExist(cneValue))
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            foreachStudent cneWindow = new foreachStudent(cneValue);
                            cneWindow.ShowDialog();
                        });
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("La valeur CNE n'existe pas dans la table etudiant.", "Erreur", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Veuillez entrer une valeur pour le CNE.", "Erreur", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }



        private bool DoesCNEExist(string cneValue)
        {
            SqlConnection conn = new SqlConnection("Data Source=PC\\SQLEXPRESS;Initial Catalog=Gestion_Etudiant;Integrated Security=True");

            string query = "SELECT COUNT(*) FROM etudiants WHERE CNE = @CNE";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CNE", cneValue);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

       

    }
}
