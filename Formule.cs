using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

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
            set { _tempsPreparation = value; }
        }

        public List<Plat> mesPlats
        {
            get { return _plats; }
            protected set { _plats = value; }
        }

        public DateTime monTempsPresence
        {
            get { return _tempsPresence; }
            set { _tempsPresence = value; }
        }

        public string monNom
        {
            get { return _nom; }
            set { _nom = value; }
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

        /// <summary>
        /// Cette méthode va permettre d'afficher le contenu de la formule.
        /// </summary>
            public override string ToString()
            {
                string texte = "";
                texte = texte + "\nFormule" + monNom + " : \n", monNom);
                foreach (Plat plat in mesPlats)
                {
                    Console.WriteLine(plat.ToString());
                }
                return texte;
            }

        /// <summary>
        /// Calcule le temps de préparation de la formule.
        /// </summary>
        public void calculTempsPreparation()
        {
            DateTime tpsprepa = mesPlats[0].monTempsPreparation;
            foreach (Plat plat in mesPlats)
            { tpsprepa.Add(plat.monTempsPreparation.TimeOfDay); }
            monTempsPreparation = tpsprepa;
        }

        /// <summary>
        /// Calcule le temps de présence dû à la formule.
        /// </summary>
        public void calculTempsPresence()
        {
            DateTime tpspres = mesPlats[0].monTempsPresence;
            foreach (Plat plat in mesPlats)
            { tpspres.Add(plat.monTempsPresence.TimeOfDay); }
            monTempsPresence = tpspres;
        }
            /// <summary>
            /// Cette fonction va permettre de chercher un plat en particulier dans une formule.
            /// </summary>
            /// <param name=""></param> 
            public Plat cherchePlat(string nomPlat)
            {
                Plat plat = null;
                if (mesPlats.Exists(item => item.monNom == nomPlat))
                {
                    plat = mesPlats.Find(item => item.monNom == nomPlat);
                }

                return plat;
            }

        /// <summary>
        /// Ajoute un plat à la formule
        /// </summary>
        /// <param name="nomPlat">Le nom du plat à ajouter. On ne peut pas mettre deux fois le même plat dans une même formule.</param>
            public void addPlat(Plat nomPlat)
            {
                Console.WriteLine("*** Ajout d'un plat à la formule ***");
                Plat plat; 
                plat = cherchePlat(nomPlat.monNom);
                if (plat != null)
                { Console.WriteLine("Ce plat existe déjà dans la formule"); }
                else
                {
                    mesPlats.Add(nomPlat);
                    Console.WriteLine("Le plat a été ajouté");
                monTempsPreparation.Add(nomPlat.monTempsPreparation.TimeOfDay);
                monTempsPresence.Add(nomPlat.monTempsPresence.TimeOfDay);
                }   
            }

        /// <summary>
        /// Supprime un plat de la formule.
        /// </summary>
        /// <param name="nomPlat">Nom du plat à supprimer.</param>
        public void deletePlat(Plat nomPlat)
                        {
                Console.WriteLine("*** Suppression d'un plat à la formule ***");
                Plat plat; 
                plat = cherchePlat(nomPlat.monNom);
                if (plat == null)
                { Console.WriteLine("Ce plat n'existe pas dans la formule"); }
                else
                {
                    mesPlats.Remove(nomPlat);
                    Console.WriteLine("Le plat a été supprimé");
                    monTempsPreparation.Add(-nomPlat.monTempsPreparation.TimeOfDay);
                    monTempsPresence.Add(-nomPlat.monTempsPresence.TimeOfDay);
                }   
            }




        #endregion
    }
}
