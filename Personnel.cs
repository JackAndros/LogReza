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
        protected bool[] _joursTravail = new bool[7];
        protected DateTime[] _horairesTravail;
        private Etat _etat;

        #endregion


        #region getters/setters

        [XmlElement("NbTotalSalarie")]
        public int monNbTotalSalarie
        {
            get { return _nbTotalSalarie; }
            set { _nbTotalSalarie = value; }
        }

        [XmlElement("NumSalarie")]
        public int monNumSalarie
        {
            get { return _numSalarie; }
            set { _numSalarie = value; }
        }

        [XmlElement("Prenom")]
        public string monPrenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }


        [XmlElement("Nom")]
        public string monNom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        [XmlArray("JoursTravail")]
        [XmlArrayItem("JourTravail")]
        public bool[] mesJoursTravail
        {
            get { return _joursTravail; }
            set { _joursTravail = value; }
        }

        [XmlArray("HorairesTravail")]
        [XmlArrayItem("HoraireTravail")]
        public DateTime[] mesHorairesTravail
        {
            get { return _horairesTravail; }
            set { _horairesTravail = value; }
        }

        [XmlElement("Etat")]
        public Etat monEtat
        {
            get { return _etat; }
            set { _etat = value; }
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
            monEtat = Etat.disponible;
        }

        #endregion


        #region methodes

        public void changerEtat(Etat nouvEtat)
        {
            monEtat = nouvEtat;
            Console.WriteLine("L'état de {0} {1} a été changé en {2}", monPrenom, monNom, nouvEtat);
        }


        #endregion

        #region enumerations

        new public enum Etat { absent, disponible, occupe }
        #endregion
    }
}

