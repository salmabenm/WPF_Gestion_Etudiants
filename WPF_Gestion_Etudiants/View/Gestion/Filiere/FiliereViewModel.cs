using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using WPF_Gestion_Etudiants.Data;
using WPF_Gestion_Etudiants.Models;

namespace WPF_Gestion_Etudiants.View.Gestion.Filiere
{
    internal class FiliereViewModel : INotifyPropertyChanged
    {
        private int selectedIndex;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<FiliereModel> filieres;
        public ObservableCollection<FiliereModel> Filieres
        {
            get { return filieres; }
            set
            {
                if (filieres != value)
                {
                    filieres = value;
                    OnPropertyChanged(nameof(Filieres));
                }
            }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    OnPropertyChanged(nameof(SelectedIndex));
                    OnPropertyChanged(nameof(SelectedFiliere));
                }
            }
        }

        public FiliereModel SelectedFiliere
        {
            get
            {
                if (SelectedIndex >= 0 && SelectedIndex < Filieres.Count)
                {
                    return Filieres[SelectedIndex];
                }

                return null;
            }
        }

        public FiliereViewModel()
        {
            this.Filieres = getAllFilieres();
        }

        public ObservableCollection<FiliereModel> getAllFilieres()
        {
            ObservableCollection<FiliereModel> filieresCollection = new ObservableCollection<FiliereModel>();
            using (Connections connections = new Connections())
            {
                SqlConnection connection = connections.GetConnection();
                string query = "select filiereId , Nom from filieres";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int filiereId = reader.GetInt32(0);
                            string nom = reader.GetString(1);

                            filieresCollection.Add(new FiliereModel(filiereId, nom));
                        }
                    }
                }
            }

            return filieresCollection;
        }

        public void AjouterFiliere(FiliereModel filiere)
        {
            using (Connections connections = new Connections())
            {
                SqlConnection connection = connections.GetConnection();
                string query = "insert into filieres (Nom) values (@nom)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nom", filiere.Nom);
                    command.ExecuteNonQuery();
                }
            }
            this.Filieres = getAllFilieres();
        }

        public void ModifierFiliere(FiliereModel filiere)
        {
            using (Connections connections = new Connections())
            {
                SqlConnection connection = connections.GetConnection();
                string query = "update filieres set Nom = @nom where filiereId = @filiereId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nom", filiere.Nom);
                    command.Parameters.AddWithValue("@filiereId", filiere.Id);
                    command.ExecuteNonQuery();
                }
            }
            this.Filieres = getAllFilieres();
        }

        public void SupprimerFiliere(FiliereModel filiere)
        {
            using (Connections connections = new Connections())
            {
                SqlConnection connection = connections.GetConnection();
                string query = "delete from filieres where filiereId = @filiereId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@filiereId", filiere.Id);
                    command.ExecuteNonQuery();
                }
            }
            this.Filieres = getAllFilieres();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
