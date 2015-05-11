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
        private string _etat;

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
            get { return _etat; }
            protected set { _etat = value; }
        }
        


        #endregion


        #region constructeur

            public Personnel() { }

            public Personnel(string nomPerso, string prenomPerso, ) {
                monNumSalarie = monNbTotalSalarie;
                monNbTotalSalarie++;
                mesJoursTravail = new bool[7];
                mesHorairesTravail = new DateTime[7];
                monEtat = "Libre";

            }

        #endregion


        #region methodes



        #endregion

    }
}
