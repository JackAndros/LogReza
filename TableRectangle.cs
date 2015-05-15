using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace LogicielReservation
{
    public class TableRectangle : TableJumelable
    {
        #region variables


        #endregion


        #region accesseurs



        #endregion


        #region constructeur

        public TableRectangle()
        {
            int[] Places = new int[4];
            bool[] Jumelables = new bool[4];

            bool intEntered = false;
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

            #endregion

            monNbPlaces = Places;

        }

        #endregion


        #region methodes



        #endregion


    }
}
