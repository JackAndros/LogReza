using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LogicielReservation {
    public class TableCombinee : TableJumelable {
        #region variables

        [XmlIgnore]
        private List<TableJumelable> tablesMeComposant;

        
        #endregion

        #region accesseurs

        [XmlArray("Tables")]
        [XmlArrayItem("Table")]
        public List<TableJumelable> MesTablesMeComposant {
            get { return tablesMeComposant; }
            set { tablesMeComposant = value; }
        }


        #endregion

        #region constructeur

        public TableCombinee() { }

        public TableCombinee(int nbCotes, TableJumelable t1, TableJumelable t2)  : base(nbCotes) {
            ajouterTable(t1);
            ajouterTable(t2);
        }

        #endregion

        #region methodes

        public void ajouterTable(TableJumelable t) {
            MesTablesMeComposant.Add(t);
        }

        #endregion

    }
}
