using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace LogicielReservation
{
    public class Formule
    {
        #region variables

        protected string _nom;
        private List<Plat> _plats;
        protected DateTime _tempsPresence;
        protected DateTime _tempsPreparation;

        #endregion


        #region getters/setters

        public DateTime monTempsPreparation
        {
            get { return _tempsPreparation; }
            protected set { _tempsPreparation = value; }
        }

        public List<Plat> mesPlats
        {
            get { return _plats; }
            protected set { _plats = value; }
        }

        public DateTime monTempsPresence
        {
            get { return _tempsPresence; }
            protected set { _tempsPresence = value; }
        }

        public string monNom
        {
            get { return _nom; }
            protected set { _nom = value; }
        }


        #endregion


        #region constructeur

            public Formule() { }

            public Formule(string nomFormule, Plat nomPlat) {
                monNom = nomFormule;
                mesPlats.Add(nomPlat);
                monTempsPreparation = nomPlat.monTempsPreparation;
                monTempsPresence = nomPlat.monTempsPresence;


            }

        #endregion


        #region methodes



        #endregion
    }
}
