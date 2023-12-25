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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Gestion_Etudiants.Data;
using WPF_Gestion_Etudiants.View.Gestion;
using WPF_Gestion_Etudiants.View.Registre;

namespace WPF_Gestion_Etudiants.View.Login
{
    /// <summary>
    /// Logique d'interaction pour login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userEmail = email.Text;
            string userPassword = password.Password;

            
            using (Connections connections = new Connections())
            {
                
                SqlConnection connection = connections.GetConnection();

                string query = "SELECT Login, Password FROM users WHERE Login = @Login AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, Connections.connection))
                {
                    command.Parameters.AddWithValue("@Login", userEmail);
                    command.Parameters.AddWithValue("@Password", userPassword);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        if (reader.Read())
                        {
                        
                            Accueil acc = new Accueil();
                            acc.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Login or password incorrect");
                        }
                    }
                }
            }
        }

        private void Button_ClickRegister(object sender, RoutedEventArgs e)
        {
            registre registreWindow = new registre();
            registreWindow.Show();

            Close();
        }
    }
}
