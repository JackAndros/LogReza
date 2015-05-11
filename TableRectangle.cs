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

        public TableRectangle()
        {

                bool intEntered = false;
                int[] Places = new int[4];
                bool[] Jumelables = new bool[4];
                string demande;
                int entARetourner = 0;


                #region 1er côté

                while (intEntered == false)
                { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    Console.WriteLine("Combien de places y a-t-il sur le 1er côté de la table ?");
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    intEntered = Int32.TryParse(demande, out entARetourner);
                }
                intEntered = false;
                Places[0] = entARetourner;

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
                    Jumelables[0] = false;
                }
                else
                {
                    Jumelables[0] = true;

                }
                intEntered = false;

                #endregion


                #region 2eme côté

                // Questions sur le deuxieme côté
                while (intEntered == false)
                { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    Console.WriteLine("Combien de places y a-t-il sur le 2eme côté de la table ?");
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    intEntered = Int32.TryParse(demande, out entARetourner);
                }
                intEntered = false;
                Places[1] = entARetourner;

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
                    Jumelables[1] = false;
                }
                else
                {
                    Jumelables[1] = true;

                }
                intEntered = false;

                #endregion


                #region 3eme côté

                while (intEntered == false)
                { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    Console.WriteLine("Combien de places y a-t-il sur le 3eme côté de la table ?");
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    intEntered = Int32.TryParse(demande, out entARetourner);
                }
                intEntered = false;
                Places[2] = entARetourner;

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
                    Jumelables[2] = false;
                }
                else
                {
                    Jumelables[2] = true;

                }
                intEntered = false;

                #endregion


                #region 4eme côté

                while (intEntered == false)
                { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    Console.WriteLine("Combien de places y a-t-il sur le 4eme côté de la table ?");
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    intEntered = Int32.TryParse(demande, out entARetourner);
                }
                Places[3] = entARetourner;


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
                    Jumelables[3] = false;
                }
                else
                {
                    Jumelables[3] = true;

                }

                #endregion

                monNbPlaces = Places;
                mesCotesJumelables = Jumelables;
                mesCotesJumeles = new bool[] { false, false, false, false };


            }

        #endregion


        #region methodes


        #endregion


    }
}
