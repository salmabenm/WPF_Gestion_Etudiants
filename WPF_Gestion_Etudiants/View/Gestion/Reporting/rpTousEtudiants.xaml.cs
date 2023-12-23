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
using System.Windows.Shapes;
using SAPBusinessObjects.WPF.Viewer;

namespace WPF_Gestion_Etudiants.View.Gestion.Reporting
{
    /// <summary>
    /// Logique d'interaction pour rpTousEtudiants.xaml
    /// </summary>
    public partial class rpTousEtudiants : Window
    {
        public rpTousEtudiants()
        {
            InitializeComponent();
        }

        private void CrystalReportsViewer_Loaded(object sender, RoutedEventArgs e)
        {
            crptStudentReport crpt = new crptStudentReport();
            crystalReportViewer1.ViewerCore.ReportSource = null;
            crystalReportViewer1.ViewerCore.ReportSource = crpt;
        }
    }
}
