using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LogicielReservation
{
    [Serializable()]
    public class Restaurant
    {
        #region variables

        protected List<Salle> _salles;
        protected List<Personnel> _personnels;
        protected List<Formule> _formules;
        protected List<Reservation> _reservations;
        protected DateTime[] _horaires;
        protected string _nom;
        protected string _motDePasse;

        #endregion


        #region getters/setters
        
        [XmlElement("Nom")]
        public string monNom
        {
            get { return _nom; }
            protected set { _nom = value; }
        }

        [XmlElement("MotDePasse")]
        public string monMotDePasse
        {
            get { return _motDePasse; }
            protected set { _motDePasse = value; }
        }

        [XmlArray("Salles")]
        [XmlArrayItem("Salle")]
        public List<Salle> mesSalles
        {
            get { return _salles; }
            protected set { _salles = value; }
        }

        [XmlArray("Personnels")]
        [XmlArrayItem("Personnel")]
        [XmlIgnore]
        public List<Personnel> mesPersonnels
        {
            get { return _personnels; }
            protected set { _personnels = value; }
        }

        [XmlArray("Formules")]
        [XmlArrayItem("Formule")]
        public List<Formule> mesFormules
        {
            get { return _formules; }
            protected set { _formules = value; }
        }

        [XmlArray("Reservations")]
        [XmlArrayItem("Reservation")]
        public List<Reservation> mesReservations
        {
            get { return _reservations; }
            protected set { _reservations = value; }
        }

        [XmlArray("Horaires")]
        [XmlArrayItem("Horaire")]
        public DateTime[] mesHoraires
        {
            get { return _horaires; }
            protected set { _horaires = value; }
        }
        /*
        public string DateOfBirthFormatted
        {
            get { return DateOfBirth.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); }
            set { DateOfBirth = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
        }
        */

        #endregion


        #region constructeur

        public Restaurant() { }

        public Restaurant(String restaurant, string mdp)
        {

            Directory.CreateDirectory("../../../DonneesRestaurants/" + restaurant);

            mesSalles = new List<Salle>();
            mesPersonnels = new List<Personnel>();
            mesFormules = new List<Formule>();
            mesReservations = new List<Reservation>();
            mesHoraires = new DateTime[4];
            monNom = restaurant;
            monMotDePasse = mdp;
        }   

        #endregion


        #region methodes

        public override string ToString()
        {
            string st = "";
            
            st += "Mon nom " + monNom + " \n";
            st += "Mdp " + monMotDePasse + " \n";
            
            return st;
        }


        #endregion

    }
}
