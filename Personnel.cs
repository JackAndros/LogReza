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

        [XmlIgnore]
        private int _numSalarie;
        [XmlIgnore]
        private static int _nbTotalSalarie;
        [XmlIgnore]
        protected string _nom;
        [XmlIgnore]
        protected string _prenom;
        [XmlIgnore]
        protected string _etatPersonnel;

        #endregion


        #region accesseurs

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

        [XmlElement("EtatPersonnel")]
        public string monEtatPersonnel
        {
            get { return _etatPersonnel; }
            set { _etatPersonnel = value; }
        }



        #endregion


        #region constructeur

        public Personnel()
        {
        }

        public Personnel(string n, string p)
        {
            monNom = n;
            monPrenom = p;
            monNumSalarie = monNbTotalSalarie;
            monNbTotalSalarie = monNbTotalSalarie + 1;
            //monEtatPersonnel = EtatPersonnel.disponible;
            monEtatPersonnel = "disponible";
        }

        #endregion


        #region methodes

        public override string ToString() {
            string texte = "";
            texte = "Le personnel "+monNom+" "+monPrenom+" est du type "+this.GetType()+". Son état : "+monEtatPersonnel+".";
            return texte;
        }


        public void changerEtatPersonnel(string nouvEtatPersonnel)
        {
            monEtatPersonnel = nouvEtatPersonnel;
            Console.WriteLine("L'état de {0} {1} a été changé en {2}", monPrenom, monNom, nouvEtatPersonnel);
        }


        #endregion


    }
}

