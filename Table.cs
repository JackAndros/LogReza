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
    public abstract class Table
    {

        #region variables

        [XmlIgnore]
        public int _nbTable;
        [XmlIgnore]
        protected static int _nbTotalTables;
        [XmlIgnore]
        protected string _etat;
        [XmlIgnore]
        protected bool _mobile;

        #endregion


        #region accesseurs

        [XmlElement("NumeroTable")]
        public int monNumTable
        {
            get { return _nbTable; }
            set { _nbTable = value; }
        }

        [XmlElement("NombreTotalTable")]
        public int monNombreTotalTables
        {
            get { return _nbTotalTables; }
            set { _nbTotalTables = value; }
        }

        [XmlElement("Etat")]
        public string monEtat
        {
            get { return _etat; }
            set { _etat = value; }
        }

        [XmlElement("Mobilite")]
        public bool maMobilite
        {
            get { return _mobile; }
            set { _mobile = value; }
        }


        #endregion


        #region constructeur

        public Table() { }

        public Table(bool mobile) {
            monNumTable = monNombreTotalTables;
            monNombreTotalTables = monNombreTotalTables +1;
            monEtat = "Libre";
            maMobilite = mobile;
        }


        #endregion


        #region methodes

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public override string ToString()
        {
            string st = "";
            st += "Mon numero:" + monNumTable + ", mon état :" + monEtat + ", ma mobilite:" + maMobilite;
            return st;
        }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public void ajouterTable() {

        }

            


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public virtual void sauveTable(XmlDocument docResto, XmlNode listeTables) { }


        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        /// <param name=""></param> 
        public static int demanderEntier(int entierDebut, int entierFin)
        {
            int entARetourner = 0;
            bool boolean = false;
            string demande;
            // Si entierDebut ou entierFin vaut -1, il n'est pas considéré utile
            if ((entierDebut != -1) && (entierFin == -1))
            {
                while ((boolean == false) || (entARetourner < entierDebut))
                { // Il faut absolument que ce qu'entre l'utilisateur soit un nombre
                    Console.WriteLine("Entrez un entier supérieur ou égal à {0}.", entierDebut);
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    boolean = Int32.TryParse(demande, out entARetourner);
                }
            }
            else if ((entierDebut == -1) && (entierFin != -1))
            {
                entARetourner = 5000;
                while ((boolean == false) || (entARetourner > entierFin))
                {
                    Console.WriteLine("Entrez un entier inférieur ou égal à {0}.", entierFin);
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    boolean = Int32.TryParse(demande, out entARetourner);
                    if (entARetourner == 0) entARetourner = 5000;
                }
            }
            else
            {
                while ((boolean == false) || (entARetourner > entierFin) || (entARetourner < entierDebut))
                {
                    Console.WriteLine("Entrez un entier compris entre {0} et {1}.", entierDebut, entierFin);
                    Console.Write("-> ");
                    demande = Console.ReadLine();
                    boolean = Int32.TryParse(demande, out entARetourner);
                }
            }
            return entARetourner;
        }

        #endregion


    }
}
