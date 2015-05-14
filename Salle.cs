using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Reflection;

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
            set { _tablesreservees = value; }
        }

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

        public Salle() {

        }

        public Salle(string nom) {
            monNom = nom;
            mesTables = new List<Table>();
            mesTablesReservees = new List<TableReservee>();
        }

        #endregion


        #region methodes

            /// <summary>
            /// Cette fonction va permettre de 
            /// </summary>
            /// <param name=""></param> 
            public List<string> tousTypesTables() {
                List<string> list = new List<string>();
                List<object> listType = new List<object>();
                var listeEnfants = Assembly.GetAssembly(typeof(Table)).GetTypes().Where(t => t.IsSubclassOf(typeof(Table)));
                //Console.WriteLine("typeList : " + listeEnfants.GetType());

                /*
                var listeEnfants = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                                from assemblyType in domainAssembly.GetTypes()
                                where typeof(Table).IsSubclassOf(assemblyType)
                                select assemblyType).ToArray();
                */
                foreach (var item in listeEnfants) {
                    list.Add(item.ToString().Split(new Char[] { '.' })[1]);
                    listType.Add(item);
                    //Console.WriteLine("typeChild : " + item.GetType());
                    //Console.WriteLine("typeChildString : " + item.ToString());

                    //Console.WriteLine(item.ToString().Split(new Char[] { '.' })[1]);
                }

                return list;
            }

            /// <summary>
            /// Cette fonction va permettre de 
            /// </summary>
            /// <param name=""></param> 
            public void ajouterTable() {
                //Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*********************************");
                Console.WriteLine("******* Ajout d'une table *******");
                Console.WriteLine("*********************************");
                Console.WriteLine("*** Quelle type de table voulez-vous ajouter ?");
                Console.ResetColor();

                List<string> typesTables = tousTypesTables();

                bool choixOk = false;
                int choix = 0;

                
                do {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*** Choisissez votre type de table parmi la liste ci-dessous");
                    Console.WriteLine();
                    Console.ResetColor();


                    for (int i = 0; i < typesTables.Count(); i++) {
                        Console.WriteLine("[{0}]  : {1}", i, typesTables[i]);
                    }

                    choixOk = Int32.TryParse(Console.ReadLine(), out choix);

                }
                while (!choixOk && (choix > typesTables.Count()) && (choix < 0));

                Table t;

                switch (choix) {
                    case 1:
                        t = new TableRectangle();
                        break;
                    case 2:
                        t = new TableRonde();
                        break;
                }
                
            }


            /// <summary>
            /// Cette fonction va permettre de 
            /// </summary>
            /// <param name=""></param> 
            public void supprimerTable(Table t) {


            }


            /// <summary>
            /// Cette fonction va permettre de 
            /// </summary>
            /// <param name=""></param> 
            public void chercheTable() {


            }


            /// <summary>
            /// Cette fonction va permettre de 
            /// </summary>
            /// <param name=""></param> 
            public void cherchePositionTable() {


            }


            /// <summary>
            /// Cette fonction va permettre de 
            /// </summary>
            /// <param name=""></param> 
            public void jumelerTables(Table table1, Table table2) {

            }

            /// <summary>
            /// Cette fonction va permettre de 
            /// </summary>
            /// <param name=""></param> 
            public void dejumelerTables(Table table1, Table table2) {

            }

            /// <summary>
            /// Cette fonction va permettre de 
            /// </summary>
            /// <param name=""></param> 
            public void actualiserTables() {


            }



            /// <summary>
            /// Cette fonction va permettre de 
            /// </summary>
            /// <param name=""></param> 
            public void actualiserTablesReservees() {


            }



        #endregion


        #region structures

        public struct TableReservee
        {
            Reservation reservation;
            Table table;

            /*
            public TableReservee() : this()
            {
                reservation = null;
                table = null;
            }
            */

            public TableReservee(Reservation res, Table tab)
            {
                reservation = res;
                table = tab;
            }
        }

        #endregion

    }
}