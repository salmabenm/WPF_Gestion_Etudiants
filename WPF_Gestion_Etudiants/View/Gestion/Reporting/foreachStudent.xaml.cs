﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using WPF_Gestion_Etudiants.View.Gestion.Reporting.StudentDataSetTableAdapters;
using SAPBusinessObjects.WPF.Viewer;


namespace WPF_Gestion_Etudiants.View.Gestion.Reporting
{
    /// <summary>
    /// Logique d'interaction pour foreachStudent.xaml
    /// </summary>
    public partial class foreachStudent : Window
    {
        private string numIdentity;
        public foreachStudent(string cmd)
        {
            InitializeComponent();
            this.numIdentity = cmd;
        }

        private void CrystalReportsViewer_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-11MQR6U\\SQLEXPRESS; Initial Catalog=Gestion_Etudiant; Integrated Security=true");
                StudentDataSet ds = new StudentDataSet();
                StudentTableAdapter da = new StudentTableAdapter();
                crptForEach cr = new crptForEach();
                da.Fill(ds.Student);
                cr.SetDataSource(ds);

                // Assurez-vous que votre rapport a une formule de sélection nommée "SelectionFormula" dans votre rapport Crystal Reports.
                // Vous devez appliquer la formule de sélection sur le rapport, pas sur le CrystalReportsViewer.

                // Exemple de formule de sélection (remplacez "CNE" par le champ approprié de votre rapport) :
                cr.RecordSelectionFormula = "{student.CNE}='" + numIdentity + "'";

                crystalReportViewer2.ViewerCore.ReportSource = cr;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
