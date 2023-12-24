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

namespace WPF_Gestion_Etudiants.View.Gestion.Statistique
{

    public partial class InfoCard : UserControl
    {
        public InfoCard()
        {
            InitializeComponent();
        }



        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(InfoCard), new PropertyMetadata(""));


        public double pourcentage
        {
            get { return (double)GetValue(pourcentageProperty); }
            set { SetValue(pourcentageProperty, value); }
        }
        public static readonly DependencyProperty pourcentageProperty =
            DependencyProperty.Register("pourcentage", typeof(double), typeof(InfoCard), new PropertyMetadata(0.0));


        public int numberOfStudent
        {
            get { return (int)GetValue(numberOfStudentProperty); }
            set { SetValue(numberOfStudentProperty, value); }
        }
        public static readonly DependencyProperty numberOfStudentProperty =
            DependencyProperty.Register("numberOfStudent", typeof(int), typeof(InfoCard), new PropertyMetadata(0));



    }




}
