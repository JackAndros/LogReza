using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LogicielReservation
{
    public class Cuisinier : Personnel
    {
        #region variables

        #endregion

        #region accesseurs

        #endregion

        #region constructeurs

        public Cuisinier()
        {
        }

        public Cuisinier(string n, string p)
            : base(n, p)
        {
        }
        #endregion
    }
}