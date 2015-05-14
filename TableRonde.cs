using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

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
            protected set { _nbPlaces = value; }
        }


        #endregion


        #region constructeur

            public TableRonde() { }

            public TableRonde(int places, bool mobilite) : base(mobilite) {
                monNbPlaces = places;
            }

        #endregion


        #region methodes

            /// <summary>
            /// Cette fonction va permettre de 
            /// </summary>
            /// <param name=""></param> 
            public override void sauveTable(XmlDocument docResto, XmlNode listeTables)
            {
                XmlNode rootNode = docResto.CreateElement("table");

                XmlAttribute typeTable = docResto.CreateAttribute("typeTable");
                typeTable.Value = this.GetType().ToString();
                rootNode.Attributes.Append(typeTable);

                XmlNode numTable = docResto.CreateElement("NumeroTable");
                numTable.InnerText = this.monNumTable.ToString();
                XmlNode mobilite = docResto.CreateElement("Mobilite");
                mobilite.InnerText = this.maMobilite.ToString();
                XmlNode etat = docResto.CreateElement("Etat");
                etat.InnerText = this.monEtat.ToString();

                rootNode.AppendChild(numTable);
                rootNode.AppendChild(mobilite);
                rootNode.AppendChild(etat);

                listeTables.AppendChild(rootNode);
            }


        #endregion

    }
}
