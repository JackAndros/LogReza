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

        [XmlIgnore]
        private string _nom;
        [XmlIgnore]
        private string _typePlat;
        [XmlIgnore]
        private DateTime _tempsPresence;
        [XmlIgnore]
        private DateTime _tempsPreparation;

        

        #endregion


        #region accesseurs

        [XmlElement("TempsPreparation")]
        public DateTime monTempsPreparation
        {
            get { return _tempsPreparation; }
            set { _tempsPreparation = value; }
        }


        [XmlElement("TempsPresence")]
        public DateTime monTempsPresence
        {
            get { return _tempsPresence; }
            set { _tempsPresence = value; }
        }


        [XmlElement("TypePlay")]
        public string monTypePlat
        {
            get { return _typePlat; }
            set { _typePlat = value; }
        }


        [XmlElement("Nom")]
        public string monNom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        

        #endregion


        #region constructeur

        public Plat() { }

        public Plat(string nomPlat, string type, DateTime dureePresence, DateTime dureePreparation)
        {
            monNom = nomPlat;
            monTypePlat = type;
            monTempsPreparation = dureePreparation;
            monTempsPresence = dureePresence;

        }


        #endregion


        #region methodes


        public override string ToString()
        {
            string texte = "";
            texte = "Le plat " + monNom + " est du type " + monTypePlat + ". Cela prend " + monTempsPreparation + " pour le préparer et il fait rester " + monTempsPresence + " min.";
            return texte;
        }

        /// <summary>
        /// Cette fonction va permettre 
        /// </summary>
        /// <param name=""></param>
        public void ajouterPlat() {
            Console.WriteLine("*** Quel est le nom du plat ? ***");
            string nom = Console.ReadLine();
            string type = demanderTypePlat();
            DateTime prep = demanderDuree("preparation");
            DateTime pres = demanderDuree("presence");
            Plat p = new Plat(nom, type, pres, prep);
            this.monNom = nom;
            this.monTypePlat = type;
            this.monTempsPreparation = prep;
            this.monTempsPresence = pres;

        }

        /// <summary>
        /// Cette fonction va permettre 
        /// </summary>
        /// <param name=""></param>
        public string demanderTypePlat() {
            string toReturn = "";
            bool choixOk = false;
            int choix=-1;
            do {
                Console.WriteLine("");
                Console.WriteLine("*** Quel est ce type de plat ? ***");
                Console.WriteLine("\n[0] Entrée \n[1] Plat \n[2] Dessert \n\n");
                Console.WriteLine("\n---------\nEntrez votre choix\n---------\n");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            }
            while (!choixOk);
            switch (choix) {
                case 1:
                    toReturn = "Entree";
                    break;
                case 2:
                    toReturn = "Plat";
                    break;
                case 3:
                    toReturn = "Dessert";
                    break;
            }
            return toReturn;
        }

        /// <summary>
        /// Cette fonction va permettre 
        /// </summary>
        /// <param name=""></param>
        public DateTime demanderDuree(string nomDuree) {
            DateTime duree = new DateTime();
            bool choixOk = false;
            int choix;
            do {
                Console.WriteLine("");
                Console.WriteLine("*** Quelle est la durée du plat {0} ? ***", nomDuree);
                Console.WriteLine("*** (Durée en minutes) ***");
                choixOk = Int32.TryParse(Console.ReadLine(), out choix);
            } while (!choixOk);

            duree = duree.AddMinutes(choix);
            return duree;
        }

        /// <summary>
        /// Cette fonction va permettre de changer le temps de préparation du plat
        /// </summary>
        /// <param name="type">Le nouveau type du plat</param>
        public void changerTypePlat(string type)
        {
            if (monTypePlat != type)
            {
                monTypePlat = type;
                Console.WriteLine("Changement effectué");
            }
            else
            { Console.WriteLine("C'est déjà le type de ce plat."); }
        }

        /// <summary>
        /// Cette fonction va permettre de changer le temps de préparation du plat.
        /// </summary>
        /// <param name="nouvtps">Le nouveau temps de préparation du plat.</param>
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

        /// <summary>
        /// Cette fonction va permettre de changer le temps de présence dû à ce plat.
        /// </summary>
        /// <param name="nouvtps">Le nouveaux temps de présence dû à ce plat.</param>
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


        #region serialisation

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        public void serializer() {
            XmlSerializer xs = new XmlSerializer(typeof(Plat));
            // Ouverture de l'instance d'écriture en précisant le chemin du fichier
            using (TextWriter writer = new StreamWriter("./..//..//DonneesRestaurants//" + monNom + "//Plats.xml")) {
                xs.Serialize(writer, this);
            }

            Console.WriteLine(string.Format("Plat : enregistrement réussi"));
        }

        /// <summary>
        /// Cette fonction va permettre de 
        /// </summary>
        public void deserializer() {
            Plat p;
            if (File.Exists("./..//..//Restaurant.xml")) {
                XmlSerializer xs = new XmlSerializer(typeof(Plat));
                using (StreamReader sr = new StreamReader("./..//..//DonneesRestaurants//" + monNom + "//Plats.xml")) {
                    p = xs.Deserialize(sr) as Plat;
                }
            }
        }

        #endregion

    }
}
