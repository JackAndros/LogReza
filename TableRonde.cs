using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LogicielReservation 
{
    public class TableRonde : Table
    {
        #region variables

        private int _nbPlaces;

        

        #endregion



        #region getters/setters

        [XmlElement("NbPlaces")]
        public int monNbPlaces
        {
            get { return _nbPlaces; }
            set { _nbPlaces = value; }
        }


        #endregion


        #region constructeur


        #endregion


        #region methodes



        #endregion

    }
}
