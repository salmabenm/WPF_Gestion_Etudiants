using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Gestion_Etudiants.Data
{
    public class Connections : IDisposable
    {
        private string strConn = "Data Source=DESKTOP-7Q1OPP5\\SQLEXPRESS;Initial Catalog=Gestion_Etudiant;Integrated Security=True;";
        public static SqlConnection connection;

        public SqlConnection GetConnection()
        {
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = strConn;
                connection.Open();


            }
            catch (Exception e)
            {
                MessageBox.Show($"Not Connect To DB {e.Message}");
            }

            return connection;
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public Connections()
        {
            GetConnection();
        }
    }

}
