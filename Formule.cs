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

        [XmlIgnore]
        protected string _nom;
        [XmlIgnore]
        private List<Plat> _plats;
        [XmlIgnore]
        protected DateTime _tempsPresence;
        [XmlIgnore]
        protected DateTime _tempsPreparation;

        #endregion


        #region accesseurs

        [XmlElement("TempsPreparation")]
        public DateTime monTempsPreparation
        {
            get { return _tempsPreparation; }
            set { _tempsPreparation = value; }
        }

        [XmlArray("Plats")]
        [XmlArrayItem("Plat")]
        public List<Plat> mesPlats
        {
            get { return _plats; }
            set { _plats = value; }
        }

        [XmlElement("TempsPresence")]
        public DateTime monTempsPresence
        {
            get { return _tempsPresence; }
            set { _tempsPresence = value; }
        }

        [XmlElement("Nom")]
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

        public override string ToString() {
            string texte = "";
            texte = "La formule " + monNom + " est composé de ";
            foreach (var plat in mesPlats) {
                texte += plat.monNom + ", ";
            }
            texte += " ela prend au total " + monTempsPreparation + " pour le préparer et il fait rester au total " + monTempsPresence + " min.";
            return texte;
        }

        public void afficherFormule()
        {
            Console.WriteLine("\nFormule {0} : \n", monNom);
            foreach (Plat plat in mesPlats)
            {
                Console.WriteLine("{0} : {1}. Temps de préparation : {2}, Temps de présence : {3}", plat.monTypePlat, plat.monNom, plat.monTempsPreparation, plat.monTempsPresence);
            }
        }

        public void calculTempsPreparation()
        {
        }

        public void calculTempsPresence()
        {

        }

            /// <summary>
            /// Cette fonction va permettre de 
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

            public void addPlat(Plat nomPlat)
            {
                Plat plat; 
                plat = cherchePlat(nomPlat.monNom);
                if (plat != null)
                { Console.WriteLine("Ce plat existe déjà dans la formule"); }
                else
                {
                    mesPlats.Add(nomPlat);
                    Console.WriteLine("Le plat a été ajouté");
                calculTempsPreparation();
                    calculTempsPresence();
                }   
            }

        public void deletePlat(Plat nomPlat)
                        {
                Plat plat; 
                plat = cherchePlat(nomPlat.monNom);
                if (plat == null)
                { Console.WriteLine("Ce plat n'existe pas dans la formule"); }
                else
                {
                    mesPlats.Remove(nomPlat);
                    Console.WriteLine("Le plat a été supprimé");
                calculTempsPreparation();
                    calculTempsPresence();
                }   
            }




        #endregion
    }
}
