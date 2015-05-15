using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace LogicielReservation
{
    public class Reservation
    {

        #region variables

        [XmlIgnore]
        private DateTime _date;
        [XmlIgnore]
        private int _nbConvives;
        [XmlIgnore]
        private Formule _formule;
        [XmlIgnore]
        private string _nomReservation;
        [XmlIgnore]
        private string _numeroTelephone;
        [XmlIgnore]
        private Table _table;

        

        #endregion


        #region accesseurs

        [XmlElement("NumeroReservation")]
        public string monNumeroReservation
        {
            get { return _numeroTelephone; }
            set { _numeroTelephone = value; }
        }

        [XmlElement("NomReservation")]
        public string monNomReservation
        {
            get { return _nomReservation; }
            set { _nomReservation = value; }
        }

        [XmlElement("Formule")]
        public Formule maFormule
        {
            get { return _formule; }
            set { _formule = value; }
        }


        [XmlElement("NbConvives")]
        public int monNbConvives
        {
            get { return _nbConvives; }
            set { _nbConvives = value; }
        }


        [XmlElement("Date")]
        public DateTime maDate
        {
            get { return _date; }
            set { _date = value; }
        }

        [XmlElement("Table")]
        public Table maTable {
            get { return _table; }
            set { _table = value; }
        }


        #endregion


        #region constructeur

        public Reservation() { }

        public Reservation(DateTime dateRes, int convives, Formule formuleChoisie, string nomPersonneQuiReserve, string numeroTelephone) {
            maDate = dateRes;
            monNbConvives = convives;
            maFormule = formuleChoisie;
            monNomReservation = nomPersonneQuiReserve;
            monNumeroReservation = numeroTelephone;
            
        }

        #endregion


        #region methodes
        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public override string ToString() {
            string texte = "";
            texte = "La table " + maTable.monNumTable + " a été réservé à " + maDate + " au nom de " + monNomReservation + " avec le numéro"+monNumeroReservation+". ";
            texte += "La formule " + maFormule.monNom + " a été réservé pour " + monNbConvives + " convives.";
            return texte;
        }


        #endregion

    }
}
