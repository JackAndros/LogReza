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

        private DateTime _date;
        private int _nbConvives;
        private string _formule;
        private string _nomReservation;
        private string _numeroTelephone;


        #endregion


        #region getters/setters

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
        public string maFormule
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
        

        #endregion


        #region constructeur

        public Reservation() { }

        public Reservation(DateTime dateRes, int convives, string formuleChoisie, string nomPersonneQuiReserve, string numeroTelephone) {
            maDate = dateRes;
            monNbConvives = convives;
            maFormule = formuleChoisie;
            monNomReservation = nomPersonneQuiReserve;
            monNumeroReservation = numeroTelephone;
            
        }

        #endregion


        #region methodes



        #endregion

    }
}
