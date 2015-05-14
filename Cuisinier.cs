using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LogicielReservation
{
    public class Cuisinier : Personnel
    {
        #region variables

        private double _rythmetravail;
        private List<Type> _capacites;


        #endregion

        #region getters/setters

        public double monRythme
        {
            get { return _rythmetravail; }
            protected set { _rythmetravail = value; }
        }

        public List<Type> mesCapacites
        {
            get { return _capacites; }
            protected set { _capacites = value; }
        }

        #endregion

        #region constructeurs

        public Cuisinier()
        {
        }

        public Cuisinier(string n, string p, bool[] jours, DateTime[] horaires, double rythme, List<Type> capas)
            : base(n, p, jours, horaires)
        {
            monRythme = rythme;
            mesCapacites = capas;
        }
        #endregion
    }
}