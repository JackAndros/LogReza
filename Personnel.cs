using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LogicielReservation
{
    public abstract class Personnel
    {

        #region variables

        private int _numSalarie;
        private static int _nbTotalSalarie;
        protected string _nom;
        protected string _prenom;
        protected bool[] _joursTravail;
        protected DateTime[] _horairesTravail;
        protected string _etatPersonnel;

        #endregion


        #region getters/setters

        [XmlElement("NbTotalSalarie")]
        public int monNbTotalSalarie
        {
            get { return _nbTotalSalarie; }
            protected set { _nbTotalSalarie = value; }
        }

        [XmlElement("NumSalarie")]
        public int monNumSalarie
        {
            get { return _numSalarie; }
            protected set { _numSalarie = value; }
        }

        [XmlElement("Prenom")]
        public string monPrenom
        {
            get { return _prenom; }
            protected set { _prenom = value; }
        }


        [XmlElement("Nom")]
        public string monNom
        {
            get { return _nom; }
            protected set { _nom = value; }
        }

        [XmlArray("JoursTravail")]
        [XmlArrayItem("JourTravail")]
        public bool[] mesJoursTravail
        {
            get { return _joursTravail; }
            protected set { _joursTravail = value; }
        }

        [XmlArray("HorairesTravail")]
        [XmlArrayItem("HoraireTravail")]
        public DateTime[] mesHorairesTravail
        {
            get { return _horairesTravail; }
            protected set { _horairesTravail = value; }
        }

        [XmlElement("Etat")]
        public string monEtat
        {
            get { return _etatPersonnel; }
            protected set { _etatPersonnel = value; }
        }



        #endregion


        #region constructeur

        public Personnel()
        {
        }

        public Personnel(string n, string p, bool[] jours, DateTime[] horaires)
        {
            jours = new bool[7];
            mesJoursTravail = jours;
            monNom = n;
            monPrenom = p;
            monNumSalarie = monNbTotalSalarie;
            monNbTotalSalarie = monNbTotalSalarie + 1;
            horaires = new DateTime[jours.Length];
            mesHorairesTravail = horaires;
            monEtat = "disponible";
        }

        #endregion


        #region methodes

        public void changerEtatPersonnel(EtatPersonnel nouvEtatPersonnel)
        {
            monEtatPersonnel = nouvEtatPersonnel;
            Console.WriteLine("L'état de {0} {1} a été changé en {2}", monPrenom, monNom, nouvEtatPersonnel);
        }

        public void changerJoursTravail(bool[] nouvJour)
        {
            if (nouvJour.Length == 7)
            {
                mesJoursTravail = nouvJour;
            }
            else
            {
                Console.WriteLine("Entrez un tableau de 7 booléens en entrée.");
            }
        }

        public void changerHoraires(DateTime[] nouvHoraires)
        {
            mesHorairesTravail = nouvHoraires;
        }
        #endregion


        #endregion

        #region enumerations

        //new public enum Etat { absent, disponible, occupe }
        #endregion
    }
}

