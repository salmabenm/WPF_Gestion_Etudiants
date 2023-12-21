using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Gestion_Etudiants.Models
{
    public class FiliereModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int? NombreEtudiant { get; set; }

        public FiliereModel(int Id, String Nom)
        {
            this.Id = Id;
            this.Nom = Nom;


        }
        public FiliereModel(int Id, String Nom, int NombreEtudiant)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.NombreEtudiant = NombreEtudiant;

        }

    }
}
