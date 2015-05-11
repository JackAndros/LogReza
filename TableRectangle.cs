using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LogicielReservation
{
    public class TableRectangle : Table
    {
        #region variables

        private int[] _nbPlaces;
        private bool[] _cotesJumelables;
        private bool[] _cotesJumeles;



        #endregion

        #region getters/setters

        [XmlElement("NbPlaces")]
        public int[] monNbPlaces
        {
            get { return _nbPlaces; }
            protected set { _nbPlaces = value; }
        }

        [XmlArray("CotesJumeles")]
        [XmlArrayItem("CoteJumeles")]
        public bool[] mesCotesJumeles
        {
            get { return _cotesJumeles; }
            protected set { _cotesJumeles = value; }
        }


        [XmlArray("CotesJumelables")]
        [XmlArrayItem("CotesJumelable")]
        public bool[] mesCotesJumelables
        {
            get { return _cotesJumelables; }
            protected set { _cotesJumelables = value; }
        }
        


        #endregion


        #region constructeur

            public TableRectangle() { }

            public TableRectangle(int[] places)
            {
                monNbPlaces = places;

                bool intEntered = false;
                int[] Places = new int[4];
                string demande;
                int entARetourner = 0;
                while (intEntered == false)
                { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    Console.WriteLine("Combien de places y a-t-il sur le 1er côté de la table ?");
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    intEntered = Int32.TryParse(demande, out entARetourner);
                }
                intEntered = false;
                places[0] = entARetourner;

                while (intEntered == false)
                {
                    Console.WriteLine("Ce côté est-t-il jumelable ?");
                    Console.WriteLine("'0':Non '1':Oui ?");
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    intEntered = Int32.TryParse(demande, out entARetourner);
                }
                if (entARetourner >= 1)
                {

                }
                else
                {

                }

                while (intEntered == false)
                { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    Console.WriteLine("Combien de places y a-t-il sur le 2eme côté de la table ?");
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    intEntered = Int32.TryParse(demande, out entARetourner);
                }
                intEntered = false;
                places[1] = entARetourner;
                while (intEntered == false)
                { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    Console.WriteLine("Combien de places y a-t-il sur le 3eme côté de la table ?");
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    intEntered = Int32.TryParse(demande, out entARetourner);
                }
                intEntered = false;
                places[2] = entARetourner;
                while (intEntered == false)
                { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    Console.WriteLine("Combien de places y a-t-il sur le 4eme côté de la table ?");
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    intEntered = Int32.TryParse(demande, out entARetourner);
                }
                places[3] = entARetourner;


            }

        #endregion


        #region methodes


        #endregion


    }
}
