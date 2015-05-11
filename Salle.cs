using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LogicielReservation
{
    public class Salle
    {
        #region variables

        protected string _nom;
        protected List<Table> _tables;

        #endregion


        #region getters/setters

        [XmlArray("Tables")]
        [XmlArrayItem("Table")]
        public List<Table> mesTables
        {
            get { return _tables; }
            set { _tables = value; }
        }

        public string monNom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        #endregion


        #region constructeur

        public Salle() { }

        public Salle() {
            mesTables = new List<Table>();
        }


        #endregion


        #region methodes



        #endregion


    }
}
