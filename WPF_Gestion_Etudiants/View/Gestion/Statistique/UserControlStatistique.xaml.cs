using LiveCharts;
using LiveCharts.Wpf;
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
using WPF_Gestion_Etudiants.Data;

namespace WPF_Gestion_Etudiants.View.Gestion.Statistique
{
    /// <summary>
    /// Logique d'interaction pour UserControlStatistique.xaml
    /// </summary>
    public partial class UserControlStatistique : UserControl
    {
        public UserControlStatistique()
        {
            InitializeComponent();

            fillChart();

            DataContext = this;

        }


        public void fillChart() {
            FilieresData data = new FilieresData();
            List<Models.FiliereModel> filieres = data.getAllFilieresWithCountOfStudent();
            int totalStudents = (int)filieres.Sum(f => f.NombreEtudiant);

            SeriesCollection = new SeriesCollection();
            this.infoCardStackPanel.Children.Clear();

            foreach (Models.FiliereModel filiere in filieres)
            {
                
                InfoCard infoCard = new InfoCard();
                infoCard.Title = filiere.Nom;
                infoCard.numberOfStudent = filiere.NombreEtudiant.Value;
                infoCard.pourcentage = (filiere.NombreEtudiant.Value * 100) / totalStudents;
                this.infoCardStackPanel.Children.Add(infoCard);


                SeriesCollection.Add(new PieSeries
                {
                    Title = filiere.Nom,
                    Values = new ChartValues<int> { filiere.NombreEtudiant.Value },
                    DataLabels = true
                });
            }
            
        }


        public SeriesCollection SeriesCollection {get;set;}


        
        private void PieChart_DataClick(object sender, LiveCharts.ChartPoint chartPoint)
        {

        }
    }
}
