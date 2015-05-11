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
        protected List<TableReservee> _tablesreservees;

        #endregion


        #region getters/setters

        [XmlArray("Tables")]
        [XmlArrayItem("Table")]
        public List<TableReservee> mesTablesReservees
        {
            get { return _tablesreservees; }
            protected set { _tablesreservees = value; }
        }

        public List<Table> mesTables
        {
            get { return _tables; }
            protected set { _tables = value; }
        }

        public string monNom
        {
            get { return _nom; }
            protected set { _nom = value; }
        }

        #endregion


        #region constructeur


        #endregion


        #region methodes



        #endregion

        #region structures
        public struct TableReservee
        {
            Reservation reservation;
            Table table;

            public TableReservee()
            {
                reservation = null;
                table = null;
            }

            public TableReservee(Reservation res, Table tab)
            {
                reservation = res;
                table = tab;
            }
        }

        #endregion

    }
}