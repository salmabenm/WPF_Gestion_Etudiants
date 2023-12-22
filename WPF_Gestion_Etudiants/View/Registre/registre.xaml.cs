using System;
using System.Collections.Generic;
using System.Data;
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
using WPF_Gestion_Etudiants.View.Login;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace WPF_Gestion_Etudiants.View.Registre
{
    public partial class registre : Window
    {
        public registre()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_ClickRegister(object sender, RoutedEventArgs e)
        {
            string username = login.Text; 
            string password = pass.Password;
            string type = fonction.Text;
            string confirmPassword = confirmpass.Password;

            if (password != confirmPassword)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas. Veuillez réessayer.");
                return; 
            }
            InsertUserIntoDatabase(username, password, type);

        }

        private void InsertUserIntoDatabase(string username, string password, string type)
        {
            using (var connection = new Connections().GetConnection())
            {
                try
                {
                   
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO users (Login, Password, Type) VALUES (@username, @Password, @Type)", connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Type", type);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("User registered successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error registering user: {ex.Message}");
                }
            }
        }

        private void Button_ClickLogin(object sender, RoutedEventArgs e)
        {

            login loginWindow = new login();
            loginWindow.Show();

            Close();
        }
    }


}

