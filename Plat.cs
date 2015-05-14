using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LogicielReservation
{
    public class Plat
    {
        #region variables

        private string _nom;
        private TypePlat _typePlat;
        private DateTime _tempsPresence;
        private DateTime _tempsPreparation;

        

        #endregion


        #region getters/setters

        public DateTime monTempsPreparation
        {
            get { return _tempsPreparation; }
            set { _tempsPreparation = value; }
        }


        public DateTime monTempsPresence
        {
            get { return _tempsPresence; }
            set { _tempsPresence = value; }
        }


        public TypePlat monTypePlat
        {
            get { return _typePlat; }
            set { _typePlat = value; }
        }


        public string monNom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        

        #endregion


        #region constructeur

        public Plat() { }

        public Plat(string nomPlat, TypePlat type, DateTime dureePresence, DateTime dureePreparation)
        {
            monNom = nomPlat;
            monTypePlat = type;
            monTempsPreparation = dureePreparation;
            monTempsPresence = dureePresence;

        }


        #endregion


        #region methodes

        public void changerTypePlat(TypePlat type)
        {
            if (monTypePlat != type)
            {
                monTypePlat = type;
                Console.WriteLine("Changement effectué");
            }
            else
            { Console.WriteLine("C'est déjà le type de ce plat."); }
        }

        public void changerTempsPreparation(DateTime nouvtps)
        {
            if (monTempsPreparation != nouvtps)
            {
                monTempsPreparation = nouvtps;
                Console.WriteLine("Changement effectué");
            }
            else
            { Console.WriteLine("C'est déjà le temps de préparation de ce plat"); }
        }

        public void changerTempsPresence(DateTime nouvtps)
        {
            if (monTempsPresence != nouvtps)
            {
                monTempsPresence = nouvtps;
                Console.WriteLine("Changement effectué");
            }
            else
            { Console.WriteLine("C'est déjà le temps de présence de ce plat"); }
        }


        #endregion

        #region enumerations
        new public enum TypePlat { Entree, Plat, Accompagnement, Dessert }
        #endregion

    }
}
