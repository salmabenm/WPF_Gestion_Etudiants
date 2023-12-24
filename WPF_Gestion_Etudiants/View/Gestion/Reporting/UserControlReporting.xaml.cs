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
using WPF_Gestion_Etudiants.View.Login;

namespace WPF_Gestion_Etudiants.View.Gestion.Reporting
{
    /// <summary>
    /// Logique d'interaction pour UserControlReporting.xaml
    /// </summary>
    public partial class UserControlReporting : UserControl
    {
        public UserControlReporting()
        {
            InitializeComponent();
        }

        private void Button_ClickRaport(object sender, RoutedEventArgs e)
        {
            try
            {
                rpTousEtudiants studentsForm = new rpTousEtudiants();
                studentsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}");
            }
        }

        private void Button_ClickForEach(object sender, RoutedEventArgs e)
        {

            selectionEtudiant selectEtudiant = new selectionEtudiant();
            selectEtudiant.Show();
        }
    }
}
