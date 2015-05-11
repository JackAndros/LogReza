using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LogicielReservation
{
    public abstract class Table
    {

        #region variables

        public int _nbTable;
        protected static int _nbTotalTables;
        protected string _etat;
        protected bool _mobile;

        #endregion



        #region getters/setters

        public int monNumTable
        {
            get { return _nbTable; }
            protected set { _nbTable = value; }
        }

        public int monNombreTotalTables
        {
            get { return _nbTotalTables; }
            set { _nbTotalTables = value; }
        }

        public string monEtat
        {
            get { return _etat; }
            set { _etat = value; }
        }

        public bool maMobilite
        {
            get { return _mobile; }
            set { _mobile = value; }
        }


        #endregion


        #region constructeur


        #endregion


        #region methodes



        #endregion


    }
}
