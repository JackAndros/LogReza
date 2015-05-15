using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Reflection;

namespace LogicielReservation {
    public class TableJumelable : Table {
        #region proprietes

        [XmlIgnore]
        private int[] _nbPlaces;
        [XmlIgnore]
        private TableJumelable[] _cotesJumeles;

        #endregion 

        #region accesseurs

        [XmlElement("NbPlaces")]
        public int[] monNbPlaces {
            get { return _nbPlaces; }
            set { _nbPlaces = value; }
        }

        [XmlArray("CotesJumeles")]
        [XmlArrayItem("CoteJumeles")]
        public TableJumelable[] mesCotesJumeles {
            get { return _cotesJumeles; }
            set { _cotesJumeles = value; }
        }


        #endregion

        #region constructeurs

        public TableJumelable() {
            bool intEntered = false;
            string demande;
            int nb = 0;

            while (intEntered == false) { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                Console.WriteLine("Combien de côtés a votre table ?");
                Console.Write("-> ");
                demande = Console.ReadLine();
                intEntered = Int32.TryParse(demande, out nb);
            }


            monNbPlaces = new int[nb];
            mesCotesJumeles = new TableJumelable[nb];

        }

        public TableJumelable(int nbcotes) {
            monNbPlaces = new int[nbcotes];
            mesCotesJumeles = new TableJumelable[nbcotes];
        }

        #endregion 

        #region méthodes


        /// <summary>
        /// Cette fonction va permettre de jumeler des tables qui ont le même nombre de places 
        /// On ne peut, pour l'instant, que jumeler deux tables
        /// </summary>
        /// <param name=""></param> 
        public TableCombinee jumelerTables(TableJumelable table) {
            TableCombinee t = null;

            if (!(this.GetType() == t.GetType()) || (table.GetType() == t.GetType())) { // On ne combine pas plusieurs tables qui sont déjà combinés
                Console.WriteLine("Il faut que les deux côtés des tables que vous voulez jumeler aient le même nombre de places ");
                Console.WriteLine("");

                bool intEntered = false;
                string demande;
                int monCoteAJumeler = 0, sonCoteAJumeler = 0;
                bool[] mesCotesNonJumeles = this.cotesNonJumele();
                bool[] sesCotesNonJumeles = table.cotesNonJumele();

                while ((intEntered == false) && (mesCotesNonJumeles[monCoteAJumeler] != true)) { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    for (int i = 0; i < mesCotesNonJumeles.Length; i++) {
                        if (mesCotesNonJumeles[i] == true) {
                            Console.WriteLine("Côte N°{0}, nombre de places : {1}", i, this.monNbPlaces[i]);
                        }
                    }

                    Console.WriteLine("A quel côté de ma table l'autre serat-telle jumelée ?");
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    intEntered = Int32.TryParse(demande, out monCoteAJumeler);
                }
                intEntered = false;

                while ((intEntered == false) && (sesCotesNonJumeles[sonCoteAJumeler] != true)) { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    for (int i = 0; i < sesCotesNonJumeles.Length; i++) {
                        if (sesCotesNonJumeles[i] == true) {
                            Console.WriteLine("Côte N°{0}, nombre de places : {1}", i, table.monNbPlaces[i]);
                        }
                    }

                    Console.WriteLine("A quel côté de l'autre table je serai jumelée ?");
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    intEntered = Int32.TryParse(demande, out monCoteAJumeler);
                }

                if (this.monNbPlaces[monCoteAJumeler] == table.monNbPlaces[sonCoteAJumeler]) {
                    this.mesCotesJumeles[monCoteAJumeler] = table;
                    table.mesCotesJumeles[monCoteAJumeler] = this;
                    int nbCotes = this.nbCotesNonJumele() + table.nbCotesNonJumele();
                    t = new TableCombinee(nbCotes, this, table);
                } else {
                    Console.WriteLine("Les côtes que vous avez choisi n'ont pas le même nombre de places");
                }
            }
            

            return t;
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public List<TableJumelable> dejumelerTables(TableJumelable table) {
            List<TableJumelable> list = new List<TableJumelable>();

            return list;

        }

        /// <summary>
        /// Cette fonction va permettre de retourner le nombre de côtés non jumelés
        /// </summary>
        /// <param name=""></param> 
        public int nbCotesNonJumele() {
            int nbReturn = 0;

            bool[] cotes = cotesNonJumele();

            foreach (var item in cotes) {
                if (item==true) {
                    nbReturn++;
                }
            }
            return nbReturn;
        }

        /// <summary>
        /// Cette fonction va permettre de retourner à 'true' les côtes de la table qui ne sont pas jumelés
        /// </summary>
        /// <param name=""></param> 
        public bool[] cotesNonJumele() {
            bool[] cotes = new bool[mesCotesJumeles.Length];

            for (int i = 0; i < mesCotesJumeles.Length; i++) {
                if (mesCotesJumeles[i] == null) {
                    cotes[i] = true;
                }
            }

            return cotes;
        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public override void sauveTable(XmlDocument docResto, XmlNode listeTables) {
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
