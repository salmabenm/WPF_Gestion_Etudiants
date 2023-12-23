using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using WPF_Gestion_Etudiants.View.Gestion.Etudiant;
using WPF_Gestion_Etudiants.View.Gestion.Filiere;
using WPF_Gestion_Etudiants.View.Gestion.Reporting;
using WPF_Gestion_Etudiants.View.Gestion.Statistique;
using WPF_Gestion_Etudiants.View.Login;

namespace WPF_Gestion_Etudiants.View.Gestion
{
    public partial class Accueil : Window
    {
       

        public Accueil()
        {
            InitializeComponent();

        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

       

        private void Etudiant_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new UserControlEtudiant();
        }

        private void Filiere_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new UserControlFiliere();
        }

        private void Statistique_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new UserControlStatistique();
        }

        private void Reporting_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new UserControlReporting();
        }

        private void Logout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            login loginWindow = new login();
            this.Close();
            loginWindow.Show();
        }
    }


}

