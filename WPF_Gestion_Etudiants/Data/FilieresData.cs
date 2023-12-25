using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Gestion_Etudiants.Models;

namespace WPF_Gestion_Etudiants.Data
{
    internal class FilieresData
    {

        private Connections connection;

        public FilieresData()
        {
            connection = new Connections();
        }


        public List<FiliereModel> getAllFilieresWithCountOfStudent()
        {
            List<FiliereModel> filieres = new List<FiliereModel>();

            try
            {
                String query = "SELECT f.filiereId, f.Nom AS FiliereName, COUNT(e.CNE) AS NombreEtudiant\r\nFROM filieres f\r\nLEFT JOIN etudiants e ON f.filiereId = e.FiliereId\r\nGROUP BY f.filiereId, f.Nom\r\nORDER BY f.filiereId;\r\n";
                using (SqlCommand commande = new SqlCommand(query, Connections.connection))
                {
                    using (SqlDataReader data = commande.ExecuteReader())
                    {
                        while (data.Read())
                        {
                            FiliereModel f = new FiliereModel(
                                (int)data[0],
                                data[1].ToString(),
                                (int)data[2]
                            );
                            filieres.Add(f);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return filieres;


        }
    }
}
