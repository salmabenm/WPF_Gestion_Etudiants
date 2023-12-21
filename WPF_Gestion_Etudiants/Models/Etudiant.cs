using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Gestion_Etudiants.Models
{
    public class Etudiant
    {
        public string CNE { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Sexe { get; set; }
        public string DateNaissance { get; set; }
        public string Addresse { get; set; }
        public string Phone { get; set; }
        public int Filiere { get; set; }
        public string FiliereName { get; set; }
        public string PhotoPath { get; set; }




        public Etudiant(string nom, string prenom, string sexe,
                        string addresse, string phone)
        {
            Nom = nom;

            Prenom = prenom;
            Sexe = sexe;
            Addresse = addresse;
            Phone = phone;


        }


        // Constructor without FiliereName
        public Etudiant(string cne, string nom, string prenom, string email, string sexe, string dateNaissance,
                        string addresse, string phone, int filiere)
        {
            CNE = cne;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Sexe = sexe;
            DateNaissance = dateNaissance;
            Addresse = addresse;
            Phone = phone;
            Filiere = filiere;
        }

        public Etudiant(string cne, string nom, string prenom, string email, string sexe, string dateNaissance,
                        string addresse, string phone, int filiere, string filiereName)
        {
            CNE = cne;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Sexe = sexe;
            DateNaissance = dateNaissance;
            Addresse = addresse;
            Phone = phone;
            Filiere = filiere;
            FiliereName = filiereName;

        }
        public Etudiant(string cne, string nom, string prenom, string email, string sexe, string dateNaissance,
                       string addresse, string phone, int filiere, string filiereName, string photopath)
        {

            CNE = cne;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Sexe = sexe;
            DateNaissance = dateNaissance;
            Addresse = addresse;
            Phone = phone;
            Filiere = filiere;
            FiliereName = filiereName;
            PhotoPath = photopath;

        }


    }
}
