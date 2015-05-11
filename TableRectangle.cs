using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LogicielReservation
{
    public class TableRectangle : Table
    {
        #region variables

        private int[] _nbPlaces;
        private bool[] _cotesJumelables;
        private bool[] _cotesJumeles;



        #endregion



        #region getters/setters

        [XmlElement("NbPlaces")]
        public int[] monNbPlaces
        {
            get { return _nbPlaces; }
            set { _nbPlaces = value; }
        }

        [XmlArray("CotesJumeles")]
        [XmlArrayItem("CoteJumeles")]
        public bool[] mesCotesJumeles
        {
            get { return _cotesJumeles; }
            set { _cotesJumeles = value; }
        }


        [XmlArray("CotesJumelables")]
        [XmlArrayItem("CotesJumelable")]
        public bool[] mesCotesJumelables
        {
            get { return _cotesJumelables; }
            set { _cotesJumelables = value; }
        }
        


        #endregion


        #region constructeur


        #endregion


        #region methodes



        #endregion


    }
}
